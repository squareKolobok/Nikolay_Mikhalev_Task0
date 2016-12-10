namespace Mikhalev_Nikolay_Task2
{
    using System;

    internal class PersonEventArgs : EventArgs
    {
        public Person Person { get; set; }

        public int Time { get; set; }
    }
}