namespace Mikhalev_Nikolay_Task1
{
    using System;

    internal class Round
    {
        private double x;
        private double y;
        private double r;

        public Round(double x, double y, double r)
        {
            this.r = r > 0 ? r : 1;
            this.x = x;
            this.y = 0;
        }

        public Round(double r) 
            : this(0, 0, r)
        {
        }

        public Round() 
            : this(0, 0, 1)
        {
        }

        public double Perimeter()
        {
            return Math.PI * 2 * r;
        }

        public double Area()
        {
            return Math.PI * Math.Pow(this.r, 2);
        }
    }
}
