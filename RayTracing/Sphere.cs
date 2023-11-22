using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class Sphere: FigureHelper
    {
        float R; // радиус

        public Pen p = new Pen(Color.Black);

        public Sphere(ThreeDpoint p, float r)
        {
            Points.Add(p);
            R = r;
        }
        public override bool IntersectionWithFigure(Ray r, out float coeff, out ThreeDpoint Norm)
        {
            coeff = 0;
            Norm = null;

            if (IntersectionWithSphere(r, Points[0], R, out coeff) && (coeff > eps))
            {
                Norm = ThreeDpoint.norm(r.Start + r.Direction * coeff - Points[0]);
                FigureMaterial.color = new ThreeDpoint(p.Color.R / 255f, p.Color.G / 255f, p.Color.B / 255f);
                return true;
            }
            return false;
        }

        public static bool IntersectionWithSphere(Ray ray, ThreeDpoint SpherePosition, float SphereRadius, out float Coeff)
        {
            float t1 = ThreeDpoint.scalar(ray.Start - SpherePosition, ray.Direction);
            float t2 = ThreeDpoint.scalar(ray.Start - SpherePosition, ray.Start - SpherePosition) - SphereRadius * SphereRadius;
            float t3 = ThreeDpoint.scalar(ray.Start - SpherePosition, ray.Direction) * ThreeDpoint.scalar(ray.Start - SpherePosition, ray.Direction) - t2;
            Coeff = 0;
            if (t3 >= 0)
            {
                if (Math.Min(-t1 + (float)Math.Sqrt(t3), -t1 - (float)Math.Sqrt(t3)) > eps)
                {
                    Coeff = Math.Min(-t1 + (float)Math.Sqrt(t3), -t1 - (float)Math.Sqrt(t3)); 
                }
                else
                {
                    Coeff = Math.Max(-t1 + (float)Math.Sqrt(t3), -t1 - (float)Math.Sqrt(t3));
                };
                return Coeff > eps;
            }
            return false;
        }

        public override void SetPen(Pen dw)
        {
            p = dw;

        }
    }
}
