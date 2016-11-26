using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mikhalev_Nikolay_Task4
{
    public abstract class Bonus
    {
        private int x;
        private int y;

        public int posY
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int posX
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Map Map
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public abstract void featureUp();
    }
}