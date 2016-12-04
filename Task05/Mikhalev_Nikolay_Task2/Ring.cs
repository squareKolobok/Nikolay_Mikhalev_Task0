namespace Mikhalev_Nikolay_Task2
{
    using System;

    internal class Ring : Round
    {
        private const double IntR= 0.5;
        private double internalR;
        public double InternalR
        {
            get
            {
                return internalR;
            }
            private set
            {
                internalR = value > 0 && value < R ? value : IntR;
            }
        }

        public Ring (double x, double y, double InternalR, double ExternalR)
            :base(x,y,ExternalR)
        {
            this.InternalR = InternalR;
        }

        public Ring(double InternalR, double ExternalR)
            :base(ExternalR)
        {
            this.InternalR = InternalR;
        }

        public Ring()
            : base()
        {
            InternalR = IntR;
        }

        public override double Perimeter()
        {
            return base.Perimeter() + Math.PI * 2 * InternalR;
        }

        public override double Area()
        {
            return base.Area() - Math.PI * Math.Pow(InternalR, 2);
        }

    }
}