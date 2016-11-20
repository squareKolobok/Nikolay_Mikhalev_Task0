namespace Mikhalev_Nikolay_Task3
{
    using System;

    internal class User
    {
        public string   Surname    { get; private set; }
        public string   Name       { get; private set; }
        public string   Patronymic { get; private set; }
        public int      Age        { get; private set; }
        public DateTime Birthdate  { get; private set; }

        public User(string surname, string name, string patronymic, DateTime birthdate, int age)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Age = age;
            Birthdate = new DateTime(birthdate.Year, birthdate.Month, birthdate.Day);
        }

        public User()
            : this("Иванов", "Иван", "Иванович", new DateTime(1960, 1, 1), 56)
        {
        }
    }
}