using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mikhalev_Nikolay_Isaev_Roman_Paint
{
    public abstract class Line
    {
        private string color;
        private int width;
        private int thickness;

        public string Color
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Figure Figure
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public abstract void Draw();
    }
}