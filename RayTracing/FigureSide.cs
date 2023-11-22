using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    public class FigureSide
    {
        public FigureHelper f = null; // объект
        public List<int> PointsList = new List<int>();
        public Pen p = new Pen(Color.Black);
        public ThreeDpoint Normal; // вектор нормали

        public FigureSide(FigureHelper h = null)
        {
            f = h;
        }
        public FigureSide(FigureSide fs)
        {
            PointsList = new List<int>(fs.PointsList);
            f = fs.f;
            p = fs.p.Clone() as Pen;
            Normal = new ThreeDpoint(fs.Normal);
        }
        //возвращает точку из списка points по заданному индексу ind
        public static ThreeDpoint Normalize(FigureSide S)
        {
            if (S.PointsList.Count() < 3)
                return new ThreeDpoint(0, 0, 0);
            return ThreeDpoint.norm((S.GetPointById(1) - S.GetPointById(0)) * (S.GetPointById(S.PointsList.Count - 1) - S.GetPointById(0)));
        }
        public ThreeDpoint GetPointById(int ind)
        {
            if (f != null)
                return f.Points[PointsList[ind]];
            return null;
        }

    }
}
