namespace Mikhalev_Nikolay_Task3
{
    using System;


    public class Ring : Circle
    {
        private double rInt;

        public Ring(Coord p1, Coord pExt, Coord pInt)
            : base(p1, pExt)
        {
            rInt = Math.Pow(Math.Pow(Math.Abs(x - pInt.x), 2) + Math.Pow(Math.Abs(y - pInt.y), 2), 0.5);
            rInt = R > rInt ? rInt : R / 2;
        }

        public new double Perim()
        {
            return base.Perim() + Math.PI * 2 * rInt;
        }

        public new double Area()
        {
            return base.Area() - Math.PI * Math.Pow(rInt, 2);
        }

        public override void WriteRes()
        {
            Console.WriteLine("кольцо имеет внутренний радиус rInt={0}, внешний радиус rExt={1} центр находится в ({2},{3})  периметр {4} и площадь {5}",
                rInt, R, x, y, Perim(), Area());
        }
    }
}
