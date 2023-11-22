using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracing
{
    public partial class Form1 : Form
    {
        public List<FigureHelper> Scene = new List<FigureHelper>();
        public List<Light> Lights = new List<Light>();   // список источников света
        public Color[,] ColorOfPixels;                    // цвета пикселей для отображения на pictureBox
        public ThreeDpoint[,] Pixels;
        public ThreeDpoint camera; // точка, к которой сфокусированы лучи при трассировке
        public ThreeDpoint LeftUp, RightUp, LeftDown, RightDown; // границы сцены
        public int h, w;

        public Form1()
        {
            InitializeComponent();
            h = pictureBox1.Height;
            w = pictureBox1.Width;     
            pictureBox1.Image = new Bitmap(w, h);
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 4;
            numericUpDown3.Value = -5;
            numericUpDown4.Value = 4;
            camera = new ThreeDpoint();
            LeftUp = new ThreeDpoint();
            RightUp = new ThreeDpoint();
            LeftDown = new ThreeDpoint();
            RightDown = new ThreeDpoint();
        }

        // трассировка лучей 
        public ThreeDpoint RayTrace(Ray r, int iter, float env)
        {
            //Для каждого созданного луча, начинаем проверять его пересечение с объектами сцены.
            if (iter <= 0)
                return new ThreeDpoint(0, 0, 0);

            float t = 0;        // позиция точки пересечения луча с фигурой на луче
            ThreeDpoint normal = null;
            Material m = new Material();
            ThreeDpoint result = new ThreeDpoint(0, 0, 0);
            bool IsRef = false; //  луч преломления проходит дальше?

            // Поиск ближайшей фигуры и определение позиции пересечения:
            foreach (FigureHelper fig in Scene)
            {
                //Расчет пересечения включает вычисление точки пересечения и нормали
                if (fig.IntersectionWithFigure(r, out float intersect, out ThreeDpoint n))

                    if (intersect < t || t == 0)     // нужна ближайшая фигура к точке наблюдения
                    {
                        t = intersect;
                        normal = n;
                        //учитываем источники света в сцене и свойства материалов объектов
                        m = new Material(fig.FigureMaterial);
                    }
            }

            if (t == 0)
                return new ThreeDpoint(0, 0, 0);

            if (ThreeDpoint.scalar(r.Direction, normal) > 0)
            {
                normal *= -1;
                IsRef = true;
            }
            //Обработка освещения с затенением по Фонгу:
            foreach (Light l in Lights)
            {
                // фоновое освещение(луна, дальний свет и пр.)
                ThreeDpoint amb = l.SourceColor * m.ambient;
                amb.x *= m.color.x;
                amb.y *= m.color.y;
                amb.z *= m.color.z;
                result += amb;

                // видима ли точка пересечения луча с фигурой из источника света
                if (CheckVisibility(l.Source, r.Start + r.Direction * t))
                    // диффузное освещение полагается на направление лучей света.
                    result += l.ShadingInterpolation(r.Start + r.Direction * t, normal, m.color, m.diffuse);  // добавляется диффузное освещение
            }
            //Обработка отражения
            if (m.reflection > 0)
                result += m.reflection * RayTrace(r.Reflection(r.Start + r.Direction * t, normal), iter - 1, env);
            //Обработка преломления
            if (m.refraction > 0)
                if (r.Refraction(r.Start + r.Direction * t, normal, IsRef ? m.environment : 1 / m.environment) != null)
                    result += m.refraction * RayTrace(r.Refraction(r.Start + r.Direction * t, normal, IsRef ? m.environment : 1 / m.environment),
                        iter - 1, m.environment);
            // итоговый цвет
            return result;
        }

  


        public void Clear()
        {
            Scene.Clear();
            Lights.Clear();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Clear();
            GetScene();
            StartRayTrace();
            for (int i = 0; i < w; ++i)
            {
                for (int j = 0; j < h; ++j)
                    (pictureBox1.Image as Bitmap).SetPixel(i, j, ColorOfPixels[i, j]);
            }
            pictureBox1.Invalidate();
        }

        private void cubeGlassCB_CheckedChanged(object sender, EventArgs e)
        {

        }
 

        public void StartRayTrace()
        {
            // получаем пискели сцены
            get_pixels();
            //Для каждого пикселя сцены создаем луч.
            for (int i = 0; i < w; ++i)
                for (int j = 0; j < h; ++j)
                {
                    // создаем новый луч
                    Ray r = new Ray(camera, Pixels[i, j]);
                    r.Start = new ThreeDpoint(Pixels[i, j]);
                    // Трассировка лучей и сохранение цвета
                    ThreeDpoint color = RayTrace(r, 10, 1);
                    if (color.x > 1.0f || color.y > 1.0f || color.z > 1.0f)
                        color = ThreeDpoint.norm(color); // нормализация цвета
                    ColorOfPixels[i, j] = Color.FromArgb((int)(255 * color.x), (int)(255 * color.y), (int)(255 * color.z));
                }
        }

        private void twoLightsCB_CheckedChanged(object sender, EventArgs e)
        {

        }
        // получение всех пикселей сцены
        public void get_pixels()
        {
            Pixels = new ThreeDpoint[w, h];
            ColorOfPixels = new Color[w, h];
            ThreeDpoint u = new ThreeDpoint(LeftUp);
            ThreeDpoint d = new ThreeDpoint(LeftDown);
            for (int i = 0; i < w; ++i)
            {
                ThreeDpoint p = new ThreeDpoint(d);
                for (int j = 0; j < h; ++j)
                {
                    Pixels[i, j] = p;
                    p += (u - d) / (h - 1);
                }
                u += (RightUp - LeftUp) / (w - 1);
                d += (RightDown - LeftDown) / (w - 1);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        public void GetScene()
        {
            // сама комната
            FigureHelper room = FigureHelper.Hexahedron(10);
            LeftUp = room.Sides[0].GetPointById(0);
            RightUp = room.Sides[0].GetPointById(1);
            RightDown = room.Sides[0].GetPointById(2);
            LeftDown = room.Sides[0].GetPointById(3);


            ThreeDpoint normal = FigureSide.Normalize(room.Sides[0]);                            // нормаль стороны комнаты
            ThreeDpoint center = (LeftUp + RightUp + LeftDown + RightDown) / 4;   // центр стороны комнаты
            camera = center + normal * 10;

            room.SetPen(new Pen(Color.Gray));

            room.isRoom = true;
            room = GetFigures(room);

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }


        // видима ли точка пересечения луча с фигурой из источника света
        public bool CheckVisibility(ThreeDpoint start, ThreeDpoint end)
        {
            foreach(FigureHelper figure in Scene)
                if (figure.IntersectionWithFigure(new Ray(end, start), out float t, out ThreeDpoint n)
                    && (t < (start - end).length()  && t > FigureHelper.eps))
                        return false;
             return true;
        }

        public FigureHelper GetFigures(FigureHelper room)
        {
            float Reflection, Refraction, Ambient, Diffusion, Environment;
            if (upWallGlassCB.Checked)
            {
                Reflection = 0.8f; Refraction = 0f; Ambient = 0.0f; Diffusion = 0.0f; Environment = 1f;
            }
            else
            {
                Reflection = 0.0f; Refraction = 0f; Ambient = 0.1f; Diffusion = 0.8f; Environment = 1f;
            }
            room.UpWallMaterial = new Material(Reflection, Refraction, Ambient, Diffusion, Environment);

            if (downWallGlassCB.Checked)
            {
                Reflection = 0.8f; Refraction = 0f; Ambient = 0.0f; Diffusion = 0.0f; Environment = 1f;
            }
            else
            {
                Reflection = 0.0f; Refraction = 0f; Ambient = 0.1f; Diffusion = 0.8f; Environment = 1f;
            }
            room.DownWallMaterial = new Material(Reflection, Refraction, Ambient, Diffusion, Environment);

            room.Sides[0].p = new Pen(Color.Green);
            if (backWallGlassCB.Checked)
            {
                Reflection = 0.8f; Refraction = 0f; Ambient = 0.0f; Diffusion = 0.0f; Environment = 1f;
            }
            else
            {
                Reflection = 0.0f; Refraction = 0f; Ambient = 0.1f; Diffusion = 0.8f; Environment = 1f;
            }
            room.BackWallMaterial = new Material(Reflection, Refraction, Ambient, Diffusion, Environment);

            room.Sides[1].p = new Pen(Color.Red);
            if (frontWallGlassCB.Checked)
            {
                Reflection = 0.8f; Refraction = 0f; Ambient = 0.0f; Diffusion = 0.0f; Environment = 1f;
            }
            else
            {
                Reflection = 0.0f; Refraction = 0f; Ambient = 0.1f; Diffusion = 0.8f; Environment = 1f;
            }
            room.FrontWallMaterial = new Material(Reflection, Refraction, Ambient, Diffusion, Environment);

            room.Sides[2].p = new Pen(Color.BlueViolet);
            if (rightWallGlassCB.Checked)
            {
                Reflection = 0.8f; Refraction = 0f; Ambient = 0.0f; Diffusion = 0.0f; Environment = 1f;
            }
            else
            {
                Reflection = 0.0f; Refraction = 0f; Ambient = 0.1f; Diffusion = 0.8f; Environment = 1f;
            }
            room.RightWallMaterial = new Material(Reflection, Refraction, Ambient, Diffusion, Environment);

            room.Sides[3].p = new Pen(Color.Plum);
            if (leftWallGlassCB.Checked)
            {
                Reflection = 0.8f; Refraction = 0f; Ambient = 0.0f; Diffusion = 0.0f; Environment = 1f;
            }
            else
            {
                Reflection = 0.0f; Refraction = 0f; Ambient = 0.1f; Diffusion = 0.8f; Environment = 1f;
            }
            room.LeftWallMaterial = new Material(Reflection, Refraction, Ambient, Diffusion, Environment);

            Lights.Add(new Light(new ThreeDpoint(0f, 1f, (float)numericUpDown4.Value - 0.1f), new ThreeDpoint(1f, 1f, 1f)));
            if (twoLightsCB.Checked)
            {
                float x = (float)numericUpDown1.Value;
                float y = (float)numericUpDown2.Value;
                float z = (float)numericUpDown3.Value;
                Lights.Add(new Light(new ThreeDpoint(x, y, z + 0.1f), new ThreeDpoint(1f, 1f, 1f)));
            }

            Sphere GlassSphere = new Sphere(new ThreeDpoint(-2.8f, -2.5f, 2.5f), 2f);
            GlassSphere.SetPen(new Pen(Color.Purple));
            if (sphereGlassCB.Checked)
            {
                Reflection = 0.9f; Refraction = 0f; Ambient = 0f; Diffusion = 0.1f; Environment = 1f;
            }
            else
            {
                Reflection = 0.0f; Refraction = 0f; Ambient = 0.1f; Diffusion = 0.8f; Environment = 1f;
            }
            GlassSphere.FigureMaterial = new Material(Reflection, Refraction, Ambient, Diffusion, Environment);

            FigureHelper RefractionCube = FigureHelper.Hexahedron(3.2f);
            RefractionCube.Offset(0.5f, -1, -3.5f);
            RefractionCube.Rotate(55, "CZ");
            RefractionCube.SetPen(new Pen(Color.Aqua));
            if (refractCubeCB.Checked)
            {
                Reflection = 0.0f; Refraction = 0.8f; Ambient = 0f; Diffusion = 0.0f; Environment = 1.03f;
            }
            else
            {
                Reflection = 0f; Refraction = 0f; Ambient = 0.1f; Diffusion = 0.7f; Environment = 1f;
            }
            RefractionCube.FigureMaterial = new Material(Reflection, Refraction, Ambient, Diffusion, Environment);

            FigureHelper GlassCube = FigureHelper.Hexahedron(2.6f);
            GlassCube.Offset(-2.4f, 2, -3.8f);
            GlassCube.Rotate(30, "CZ");
            GlassCube.SetPen(new Pen(Color.Blue));
            if (cubeGlassCB.Checked)
            {
                Reflection = 0.8f; Refraction = 0f; Ambient = 0.05f; Diffusion = 0.0f; Environment = 1f;
            }
            else
            {
                Reflection = 0.0f; Refraction = 0f; Ambient = 0.1f; Diffusion = 0.8f; Environment = 1f;
            }
            GlassCube.FigureMaterial = new Material(Reflection, Refraction, Ambient, Diffusion, Environment);

            Sphere RefractionSphere = new Sphere(new ThreeDpoint(2.5f, 2f, -3.4f), 1.7f);
            RefractionSphere.SetPen(new Pen(Color.LimeGreen));
            if (refractSphereCB.Checked)
            {
                Reflection = 0.0f; Refraction = 0.9f; Ambient = 0f; Diffusion = 0.0f; Environment = 1.03f;
            }
            else
            {
                Reflection = 0.0f; Refraction = 0f; Ambient = 0.1f; Diffusion = 0.9f; Environment = 1f;
            }
            RefractionSphere.FigureMaterial = new Material(Reflection, Refraction, Ambient, Diffusion, Environment);

            Scene.Add(room);
            Scene.Add(RefractionCube);
            Scene.Add(GlassCube);
            Scene.Add(GlassSphere);
            Scene.Add(RefractionSphere);
            return room;

        }


    }
}
