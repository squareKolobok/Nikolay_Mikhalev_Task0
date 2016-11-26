namespace Mikhalev_Nikolay_Task2
{
    using System;

    internal class Round
    {
        private double r;
        public double X { get; set; }
        public double Y { get; set; }
        public double R
        {
            get
            {
                return r;
            }
            private set
            {
                r = value > 0 ? value : 1;
            }
        }

        public Round(double x, double y, double r)
        {
            R = r;
            X = x;
            Y = y;
        }

        public Round(double r) 
            : this(0, 0, r)
        {
        }

        public Round() 
            : this(0, 0, 1)
        {
        }

        public virtual double Perimeter()
        {
            return Math.PI * 2 * R;
        }

        public virtual double Area()
        {
            return Math.PI * Math.Pow(R, 2);
        }
    }
}
