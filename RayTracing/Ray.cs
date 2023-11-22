using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    // луч
    public class Ray
    {
        public ThreeDpoint Start;
        public ThreeDpoint Direction;

        public Ray(ThreeDpoint st, ThreeDpoint end)
        {
            Start = new ThreeDpoint(st);
            Direction = ThreeDpoint.norm(end - st);
        }

        public Ray() { }

        public Ray(Ray r)
        {
            Start = r.Start;
            Direction = r.Direction;
        }

        // вычисляет отраженный луч 
        public Ray Reflection(ThreeDpoint hit_point, ThreeDpoint normal)
        {
            return new Ray(hit_point, hit_point + Direction - 2 * normal * ThreeDpoint.scalar(Direction, normal));
        }

        //Вычисляет преломленный луч 
        public Ray Refraction(ThreeDpoint hit_point, ThreeDpoint normal, float a)
        {
            Ray r = new Ray();
            if (1 - a * a * (1 - ThreeDpoint.scalar(normal, Direction) * ThreeDpoint.scalar(normal, Direction)) >= 0)
            {
                r.Start = new ThreeDpoint(hit_point);
                r.Direction = ThreeDpoint.norm(a * Direction - ((float)Math.Sqrt(1 - a * a * 
                    (1 - ThreeDpoint.scalar(normal, Direction) * ThreeDpoint.scalar(normal, Direction))) + 
                    a * ThreeDpoint.scalar(normal, Direction)) * normal);
                return r;
            }
            else
                return null;
        }
    }
}
