using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mikhalev_Nikolay_Task4
{
    public abstract class Monster
    {
        private int x;
        private int y;

        public int poxX
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

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

        public void moveTo()
        {
            throw new System.NotImplementedException();
        }

        public abstract void SearchPlayer();

        public abstract void RedusHealth();

        public abstract bool IsMoveWall();
    }
}