namespace Mikhalev_Nikolay_Task3
{
    using System;

    public class Rect : Figure
    {
        private double x2;
        private double y2;

        public Rect(Coord p1, Coord p2)
        {
            x = p1.x;
            y = p1.y;
            x2 = p2.x;
            y2 = p2.y;
        }

        public double Perim()
        {
            return Math.Abs(x - x2) * 2 + Math.Abs(y - y2) * 2;
        }

        public double Area()
        {
            return Math.Abs(x - x2) * Math.Abs(y - y2);
        }

        public override void WriteRes()
        {
            Console.WriteLine("прямоугольник имеет 4 координаты ({0},{1}), ({0},{3}), ({2},{3}), ({2},{1}), его периметр = {4}, площадь = {5}", 
                x, y, x2, y2, Perim(), Area());
        }
    }
}