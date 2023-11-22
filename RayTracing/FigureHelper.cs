using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class FigureHelper
    {
        public Material FrontWallMaterial;
        public Material BackWallMaterial;
        public Material LeftWallMaterial;
        public Material RightWallMaterial;
        public Material UpWallMaterial;
        public Material DownWallMaterial;
        public Material FigureMaterial;
        public List<ThreeDpoint> Points = new List<ThreeDpoint>(); 
        public List<FigureSide> Sides = new List<FigureSide>();       
        public static float eps = 0.0001f;
        public bool isRoom = false; 


        public FigureHelper() { }

        public FigureHelper(FigureHelper f)
        {
            foreach (ThreeDpoint p in f.Points)
                Points.Add(new ThreeDpoint(p));

            foreach (FigureSide s in f.Sides)
            {
                Sides.Add(new FigureSide(s));
                Sides.Last().f = this;
            }
        }
        private static float[,] Multiply(float[,] m1, float[,] m2)
        {
            float[,] res = new float[m1.GetLength(0), m2.GetLength(1)];
            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m2.GetLength(1); j++)
                {
                    for (int k = 0; k < m2.GetLength(0); k++)
                    {
                        res[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            return res;
        }
        public float[,] GetMatr()
        {
            var res = new float[Points.Count, 4];
            for (int i = 0; i < Points.Count; i++)
            {
                res[i, 0] = Points[i].x;
                res[i, 1] = Points[i].y;
                res[i, 2] = Points[i].z;
                res[i, 3] = 1;
            }
            return res;
        }
        private ThreeDpoint GetCenter()
        {
            ThreeDpoint res = new ThreeDpoint(0, 0, 0);
            foreach (ThreeDpoint p in Points)
            {
                res.x += p.x;
                res.y += p.y;
                res.z += p.z;

            }
            res.x /= Points.Count();
            res.y /= Points.Count();
            res.z /= Points.Count();
            return res;
        }
        public bool TriangleIntersectionWithRay(Ray r, ThreeDpoint p0, ThreeDpoint p1, ThreeDpoint p2, out float inter)
        {
            inter = -1;
            if (ThreeDpoint.scalar(p1 - p0, r.Direction * (p2 - p0)) > -eps && ThreeDpoint.scalar(p1 - p0, r.Direction * (p2 - p0)) < eps)
                return false;    

            float f = 1.0f / ThreeDpoint.scalar(p1 - p0, r.Direction * (p2 - p0));
            if (f * ThreeDpoint.scalar((r.Start - p0), r.Direction * (p2 - p0)) < 0 || f * ThreeDpoint.scalar((r.Start - p0), r.Direction * (p2 - p0)) > 1)
                return false;

            if (f * ThreeDpoint.scalar(r.Direction, (r.Start - p0) * (p1 - p0)) < 0 || f * ThreeDpoint.scalar((r.Start - p0),
                r.Direction * (p2 - p0)) + f * ThreeDpoint.scalar(r.Direction, (r.Start - p0) * (p1 - p0)) > 1)
                return false;

            if (f * ThreeDpoint.scalar(p2 - p0, (r.Start - p0) * (p1 - p0)) > eps)
            {
                inter = f * ThreeDpoint.scalar(p2 - p0, (r.Start - p0) * (p1 - p0));
                return true;
            }  
                return false;
        }
        public void RotateAroundR(float rangle, string type)
        {
            float[,] mt = GetMatr();
            ThreeDpoint center = GetCenter();
            switch (type)
            {
                case "CX":
                    mt = GetOffset(mt, -center.x, -center.y, -center.z);
                    mt = RotationX(mt, rangle);
                    mt = GetOffset(mt, center.x, center.y, center.z);
                    break;
                case "CY":
                    mt = GetOffset(mt, -center.x, -center.y, -center.z);
                    mt = RotationY(mt, rangle);
                    mt = GetOffset(mt, center.x, center.y, center.z);
                    break;
                case "CZ":
                    mt = GetOffset(mt, -center.x, -center.y, -center.z);
                    mt = RotationZ(mt, rangle);
                    mt = GetOffset(mt, center.x, center.y, center.z);
                    break;
                case "X":
                    mt = RotationX(mt, rangle);
                    break;
                case "Y":
                    mt = RotationY(mt, rangle);
                    break;
                case "Z":
                    mt = RotationZ(mt, rangle);
                    break;
                default:
                    break;
            }
            MatrApply(mt);
        }
        public void MatrApply(float[,] matrix)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i].x = matrix[i, 0] / matrix[i, 3];
                Points[i].y = matrix[i, 1] / matrix[i, 3];
                Points[i].z = matrix[i, 2] / matrix[i, 3];

            }
        }

        private static float[,] RotationY(float[,] transform_matrix, float angle)
        {
            float[,] rotationMatrix = new float[,] { { (float)Math.Cos(angle), 0, -(float)Math.Sin(angle), 0 }, { 0, 1, 0, 0 },
                { (float)Math.Sin(angle), 0, (float)Math.Cos(angle), 0}, { 0, 0, 0, 1} };
            return Multiply(transform_matrix, rotationMatrix);
        }
        public void Offset(float xs, float ys, float zs)
        {
            MatrApply(GetOffset(GetMatr(), xs, ys, zs));
        }

        public virtual void SetPen(Pen dw)
        {
            foreach (FigureSide s in Sides)
                s.p = dw;

        }

        private static float[,] GetOffset(float[,] transform_matrix, float offset_x, float offset_y, float offset_z)
        {
            float[,] translationMatrix = new float[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { offset_x, offset_y, offset_z, 1 } };
            return Multiply(transform_matrix, translationMatrix);
        }

        // пересечение луча с фигурой
        public virtual bool IntersectionWithFigure(Ray r, out float Inter, out ThreeDpoint Norm)
        {
            Inter = 0;
            Norm = null;
            FigureSide Side = null;
            int fm = -1;         

            for (int i = 0; i < Sides.Count; ++i)
            {
                
                if (Sides[i].PointsList.Count == 3)
                {
                    if (TriangleIntersectionWithRay(r, Sides[i].GetPointById(0), Sides[i].GetPointById(1), Sides[i].GetPointById(2), out float t) && (Inter == 0 || t < Inter))
                    {
                        Inter = t;
                        Side = Sides[i];
                    }
                }
                if (Sides[i].PointsList.Count == 4)
                {
                    if (TriangleIntersectionWithRay(r, Sides[i].GetPointById(0), Sides[i].GetPointById(1), Sides[i].GetPointById(3), out float t) && (Inter == 0 || t < Inter))
                    {
                        fm = i;
                        Inter = t;
                        Side = Sides[i];
                    }
                    else if (TriangleIntersectionWithRay(r, Sides[i].GetPointById(1), Sides[i].GetPointById(2), Sides[i].GetPointById(3), out t) && (Inter == 0 || t < Inter))
                    {
                        fm = i;
                        Inter = t;
                        Side = Sides[i];
                    }
                }
            }

            if (Inter != 0)
            {
                Norm = FigureSide.Normalize(Side);
                if (isRoom)
                    switch (fm)
                    {
                        case 0:
                            FigureMaterial = new Material(BackWallMaterial);
                            break;
                        case 1:
                            FigureMaterial = new Material(FrontWallMaterial);
                            break;
                        case 2:
                            FigureMaterial = new Material(RightWallMaterial);
                            break;
                        case 3:
                            FigureMaterial = new Material(LeftWallMaterial);
                            break;
                        case 4:
                            FigureMaterial = new Material(UpWallMaterial);
                            break;
                        case 5:
                            FigureMaterial = new Material(DownWallMaterial);
                            break;
                        default:
                            break;
                    }
                FigureMaterial.color = new ThreeDpoint(Side.p.Color.R / 255f, Side.p.Color.G / 255f, Side.p.Color.B / 255f);
                return true;
            }

            return false;
        }


        private static float[,] RotationX(float[,] transform_matrix, float angle)
        {
            float[,] rotationMatrix = new float[,] { { 1, 0, 0, 0 }, { 0, (float)Math.Cos(angle), (float)Math.Sin(angle), 0 },
                { 0, -(float)Math.Sin(angle), (float)Math.Cos(angle), 0}, { 0, 0, 0, 1} };
            return Multiply(transform_matrix, rotationMatrix);
        }



        public void Rotate(float angle, string type)
        {
            RotateAroundR(angle * (float)Math.PI / 180, type);
        }


 
        private static float[,] RotationZ(float[,] transform_matrix, float angle)
        {
            float[,] rotationMatrix = new float[,] { { (float)Math.Cos(angle), (float)Math.Sin(angle), 0, 0 }, { -(float)Math.Sin(angle), (float)Math.Cos(angle), 0, 0 },
                { 0, 0, 1, 0 }, { 0, 0, 0, 1} };
            return Multiply(transform_matrix, rotationMatrix);
        }

      
         // Куб          
        static public FigureHelper Hexahedron(float sz)
        {
            FigureHelper res = new FigureHelper();
            res.Points.Add(new ThreeDpoint(sz / 2, sz / 2, sz / 2)); 
            res.Points.Add(new ThreeDpoint(-sz / 2, sz / 2, sz / 2)); 
            res.Points.Add(new ThreeDpoint(-sz / 2, sz / 2, -sz / 2)); 
            res.Points.Add(new ThreeDpoint(sz / 2, sz / 2, -sz / 2)); 

            res.Points.Add(new ThreeDpoint(sz / 2, -sz / 2, sz / 2)); 
            res.Points.Add(new ThreeDpoint(-sz / 2, -sz / 2, sz / 2)); 
            res.Points.Add(new ThreeDpoint(-sz / 2, -sz / 2, -sz / 2)); 
            res.Points.Add(new ThreeDpoint(sz / 2, -sz / 2, -sz / 2)); 

            FigureSide s = new FigureSide(res);
            s.PointsList.AddRange(new int[] { 3, 2, 1, 0 });
            res.Sides.Add(s);

            s = new FigureSide(res);
            s.PointsList.AddRange(new int[] { 4, 5, 6, 7 });
            res.Sides.Add(s);

            s = new FigureSide(res);
            s.PointsList.AddRange(new int[] { 2, 6, 5, 1 });
            res.Sides.Add(s);

            s = new FigureSide(res);
            s.PointsList.AddRange(new int[] { 0, 4, 7, 3 });
            res.Sides.Add(s);

            s = new FigureSide(res);
            s.PointsList.AddRange(new int[] { 1, 5, 4, 0 });
            res.Sides.Add(s);

            s = new FigureSide(res);
            s.PointsList.AddRange(new int[] { 2, 3, 7, 6 });
            res.Sides.Add(s);

            return res;
        }
    }
}
