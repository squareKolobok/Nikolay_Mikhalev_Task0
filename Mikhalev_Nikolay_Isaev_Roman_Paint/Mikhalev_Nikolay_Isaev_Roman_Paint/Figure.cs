using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mikhalev_Nikolay_Isaev_Roman_Paint
{
    public abstract class Figure
    {
        private double x;
        private double y;
        private Line line;
        private Fill fill;

        protected double X
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        protected double Y
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Fill Fill
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Line Line
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public abstract void Render();
    }
}