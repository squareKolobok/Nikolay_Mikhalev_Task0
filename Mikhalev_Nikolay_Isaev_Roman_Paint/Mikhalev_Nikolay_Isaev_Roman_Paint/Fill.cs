using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mikhalev_Nikolay_Isaev_Roman_Paint
{
    public abstract class Fill
    {
        private string color;

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

        public abstract void filling();
    }
}