namespace Mikhalev_Nikolay_Task3
{
    using System;

    public struct Coord
    {
        public double x;
        public double y;
    }

    public class Circle : Figure
    {
        private double r;
        public double R
        {
            get
            {
                return r;
            }
        }

        public Circle(Coord p1, params Coord[] points)
        {
            x = p1.x;
            y = p1.y;
            double R = 0;

            if (points.Length == 0)
                r = 1;

            for (int i = 0; i < points.Length; i++)
                r = Math.Max(R, Math.Pow(Math.Pow(Math.Abs(x - points[i].x), 2) + Math.Pow(Math.Abs(y - points[i].y), 2), 0.5));
        }

        public double Perim()
        {
            return Math.PI * 2 * r;
        }

        public double Area()
        {
            return Math.PI * Math.Pow(r, 2);
        }

        public override void WriteRes()
        {
            Console.WriteLine("круг имеет радиус r={0} в центре ({1},{2}), периметр {3} и площадь {4}", r, x, y, Perim(), Area());
        }
    }
}
