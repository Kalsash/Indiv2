using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class Light: FigureHelper
    {
        public ThreeDpoint Source;       // точка, где находится источник света
        public ThreeDpoint SourceColor;       // цвет источника света

        public Light(ThreeDpoint p, ThreeDpoint c)
        {
            Source = new ThreeDpoint(p);
            SourceColor = new ThreeDpoint(c);
        }
        // Затенение
        public ThreeDpoint ShadingInterpolation(ThreeDpoint EndP, ThreeDpoint Norm, ThreeDpoint FigureColor, float KDiffusion)
        {     
            //Вычисляем диффузную составляющую цвета освещения
            ThreeDpoint diffusion = KDiffusion * SourceColor * Math.Max(ThreeDpoint.scalar(Norm, ThreeDpoint.norm(Source - EndP)), 0);
            return new ThreeDpoint(diffusion.x * FigureColor.x, diffusion.y * FigureColor.y, diffusion.z * FigureColor.z);
        }
    }
}
