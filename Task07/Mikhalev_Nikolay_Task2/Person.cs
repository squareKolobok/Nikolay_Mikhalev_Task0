namespace Mikhalev_Nikolay_Task2
{
    using System;

    internal class Person
    {
        public string Name { get; private set; }

        public Person(string name)
        {
            Name = name;
        }

        public void Hello(PersonEventArgs args)
        {
            if (args.Time < 12 && args.Time >= 4)
            {
                Console.WriteLine("'Доброе утро, {0}' - сказал {1}", args.Person.Name, Name);
            }

            if (args.Time >= 12 && args.Time < 17)
            {
                Console.WriteLine("'Добрый день, {0}' - сказал {1}", args.Person.Name, Name);
            }

            if ((args.Time >= 17 && args.Time < 24) || (args.Time > 0 && args.Time < 4))
            {
                Console.WriteLine("'Добрый вечер, {0}' - сказал {1}", args.Person.Name, Name);
            }
        }

        public void GoodBye(PersonEventArgs args)
        {
            Console.WriteLine("'До свидания, {0}' - сказал {1}", args.Person.Name, Name);
        }
    }
}