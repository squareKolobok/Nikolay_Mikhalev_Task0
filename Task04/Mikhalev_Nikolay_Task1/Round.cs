namespace Mikhalev_Nikolay_Task1
{
    using System;

    internal class Round
    {
        private double x;//todo лучше использовать свойства
        private double y;
        private double r;

        public Round(double x, double y, double r)
        {
            this.r = r > 0 ? r : 1;//todo валидацию значения лучше проводить в свойстве в теле set 
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
            return Math.PI * Math.Pow(this.r, 2);//todo когда ты обращаешься к полям (методам, свойствам) данного класса не обязательно перед ними ставить this
        }
    }
}
