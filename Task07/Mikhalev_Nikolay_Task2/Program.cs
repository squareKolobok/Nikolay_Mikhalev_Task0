namespace Mikhalev_Nikolay_Task2
{
    using System;

    public class Program
    {
        private static Messege cameMessege;

        private static Messege leftMessege;

        public static void Main()
        {
            Person john = new Person("John");
            Person bill = new Person("Bill");
            Person hugo = new Person("Hugo");
            Events d = new Events();

            d.CameEvent += onCame;
            d.LeftEvent += onLeft;

            d.Came(john, 11);
            d.Came(bill, 15);
            d.Came(hugo, 19);

            d.Left(john);
            d.Left(bill);
            d.Left(hugo);

            Console.WriteLine("\nНажмите Enter чтобы завершить работу");
            Console.Read();
        }

        private static void onCame(object sender, PersonEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("[{0} пришел на работу в {1} часов]", e.Person.Name, e.Time);
            cameMessege?.Invoke(new PersonEventArgs() { Person = e.Person, Time = e.Time });
            cameMessege += new Messege(e.Person.Hello);
            leftMessege += new Messege(e.Person.GoodBye);
        }

        private static void onLeft(object sender, PersonEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("[{0} ушел домой]", e.Person.Name);
            cameMessege -= new Messege(e.Person.Hello);
            leftMessege -= new Messege(e.Person.GoodBye);
            leftMessege?.Invoke(new PersonEventArgs() { Person = e.Person });
        }

        private delegate void Messege(PersonEventArgs args);
    }
}