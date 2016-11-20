namespace Mikhalev_Nikolay_Task2
{
    using System;

    internal class Triangle
    {
        private double a;
        private double b;
        private double c;

        public Triangle(double a, double b, double c)
        {
            if (a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && c + b > a)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            else
            {
                this.a = 1;
                this.b = 1;
                this.c = 1;
            }
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