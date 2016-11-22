namespace Mikhalev_Nikolay_Task2
{
    using System;

    internal class Triangle
    {
        private double a;
        private double b;
        private double c;

        private double A
        {
            set { a = value > 0 ? value : 1; }
        }

        private double B
        {
            set { b = value > 0 ? value : 1; }
        }

        private double C 
        {
            set
            {
                if (value > 0 && a + b > value && a + value > b && value + b > a)
                    c = value;
                else
                {
                    a = 1;
                    b = 1;
                    c = 1;
                }
            }
        }

        public Triangle(double a, double b, double c)
        {
                A = a;
                B = b;
                C = c;
        }

        public Triangle()
            : this(1, 1, 1)
        {
        }

        public double Perimeter()
        {
            return a + b + c;
        }

        public double Area()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}