namespace Mikhalev_Nikolay_Task3
{
    using System;

    internal class User
    {
        public string   Surname    { get; private set; }//todo что-то многовато пробелов в строках
        public string   Name       { get; private set; }
        public string   Patronymic { get; private set; }
        public int      Age        { get; private set; }
        public DateTime Birthdate  { get; private set; }

        public User(string Surname, string name, string patronymic, DateTime birthdate, int age)
        {
            this.Surname = Surname;//todo в случае, когда тебе нужно использовать одну строку и для входного параметра и для поля класса
            Name = name;
            Patronymic = patronymic;
            Age = age;//todo странно присваивать возраст человека, когда мы уже знаем его дату рождения. Сделать это поле вичислимым.
            Birthdate = new DateTime(birthdate.Year, birthdate.Month, birthdate.Day);
        }

        public User()
            : this("Иванов", "Иван", "Иванович", new DateTime(1960, 1, 1), 56)//todo значения по умолчанию лучше вынести в константы
        {
        }
    }
}