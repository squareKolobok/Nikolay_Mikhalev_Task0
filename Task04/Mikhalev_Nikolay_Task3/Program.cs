namespace Mikhalev_Nikolay_Task3
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string continWork;
            User usr = new User();

            do
            {
                Console.Clear();
                Console.Write("Выберите что хотите сделать с человеком:\n" +
                                    "\t 1: создать человека со стандартными параметрами(задан по умолчанию)\n" +
                                    "\t 2: создать человека с заданными параметрами\n" +
                                    "\t 3: узнать ФИО человека\n" +
                                    "\t 4: узнать дату рождения человека\n" +
                                    "\t 5: узнать возраст человека\n");
                int key = ReadKey();

                switch (key)
                {
                    case 1:
                        {
                            usr = new User();
                            Console.WriteLine("Человек со стандартными параметрами задан");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Введите фамилию человека");
                            string surname = Console.ReadLine();
                            Console.WriteLine("Введите имя человека");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите отчество человека");
                            string patronymic = Console.ReadLine();
                            Console.WriteLine("Введите год рождения человека");
                            int y = ReadKey();
                            Console.WriteLine("Введите месяц рождения человека");
                            int m = ReadKey();
                            Console.WriteLine("Введите день рождения человека");
                            int d = ReadKey();

                            try
                            {
                                usr = new User(surname, name, patronymic, new DateTime(y, m, d));
                                Console.WriteLine("человек с данными параметрами создан");
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Неверно введена дата рождения");
                            }

                            break;
                        }
                    case 3:
                        Console.WriteLine("ФИО человека: {0} {1} {2}", usr.Surname, usr.Name, usr.Patronymic);
                        break;
                    case 4:
                        {
                            DateTime date = usr.Birthdate;
                            Console.WriteLine("Дата рождения человека {0}.{1}.{2} (dd.mm.yyyy)", date.Day, date.Month, date.Year);
                            break;
                        }
                    case 5:
                        Console.WriteLine("Возраст человека {0}", usr.Age);
                        break;
                    default:
                        Console.WriteLine("Выбранного пункта меню не существет");
                        break;
                }

                Console.WriteLine("Желаете продолжить?(y/n - н/т)");
                continWork = Console.ReadLine();
                Console.WriteLine();
            }
            while (continWork == "y" || continWork == "н");
        }

        private static int ReadKey()
        {
            int key;

            while (!(int.TryParse(Console.ReadLine(), out key) && key > 0))
            {
                Console.WriteLine("Данные введены не верно, повторите ввод");
            }

            return key;
        }
    }
}
