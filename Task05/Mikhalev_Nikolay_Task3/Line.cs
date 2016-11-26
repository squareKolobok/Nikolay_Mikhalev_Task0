namespace Mikhalev_Nikolay_Task3
{
    using System;

    public class Line : Figure
    {
        private double x2;
        private double y2;

        public Line(Coord p1, Coord p2)
        {
            x = p1.x;
            y = p1.y;
            x2 = p2.x;
            y2 = p2.y;
        }

        public override void WriteRes()
        {
            Console.WriteLine("Линия с координатами ({0},{1}) и ({2},{3})", x, y, x2, y2);
        }
    }
}
