namespace Mikhalev_Nikolay_Task2
{
    using System;

    internal class Events
    {
        public event EventHandler<PersonEventArgs> CameEvent;

        public event EventHandler<PersonEventArgs> LeftEvent;

        public void Came(Person person, int time)
        {
            PersonEventArgs persEvent = new PersonEventArgs() { Person = person, Time = time };
            CameEvent?.Invoke(this, persEvent);
        }

        public void Left(Person person)
        {
            PersonEventArgs persEvent = new PersonEventArgs() { Person = person, Time = 0 };
            LeftEvent?.Invoke(this, persEvent);
        }
    }
}