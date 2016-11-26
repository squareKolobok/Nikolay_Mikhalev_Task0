namespace Mikhalev_Nikolay_Task3
{
    using System;

    public class Circum : Figure
    {
        private double r;

        public Circum(Coord p1, Coord p2)
        {
            x = p1.x;
            y = p1.y;
            r = Math.Pow(Math.Pow(Math.Abs(p1.x - p2.x), 2) + Math.Pow(Math.Abs(p1.y - p2.y), 2), 0.5);
        }

        public double Perim()
        {
            return Math.PI * 2 * r;
        }

        public override void WriteRes()
        {
            Console.WriteLine("окружность имеет радиус r={0} в центре ({1},{2}), ее периметр равен {3}", r, x, y, Perim());
        }
    }
}
