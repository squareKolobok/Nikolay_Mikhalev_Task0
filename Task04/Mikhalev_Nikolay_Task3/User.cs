namespace Mikhalev_Nikolay_Task3
{
    using System;

    internal class User
    {
        public const string SURNAME = "Иванов";
        public const string NAME = "Иван";
        public const string PATRONYMIC = "Иванович";
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Patronymic { get; private set; }
        public int Age { get; private set; }
        public DateTime Birthdate { get; private set; }

        public User(string Surname, string name, string patronymic, DateTime birthdate)
        {
            this.Surname = Surname;
            Name = name;
            Patronymic = patronymic;
            Birthdate = new DateTime(birthdate.Year, birthdate.Month, birthdate.Day);
            DateTime date = DateTime.Now;
            Age = new DateTime(date.Year, Birthdate.Month, Birthdate.Day) > date ? date.Year - Birthdate.Year - 1 : date.Year - Birthdate.Year;
        }

        public User()
            : this(SURNAME, NAME, PATRONYMIC, new DateTime(1960, 1, 1))
        {
        }
    }
}