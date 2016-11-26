namespace Mikhalev_Nikolay_Task01
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string continWork;
            Employee empl = new Employee();

            do
            {
                Console.Clear();
                Console.Write("Выберите что хотите сделать с сотрудником:\n" +
                                    "\t 1: создать сотрудника со стандартными параметрами(задан по умолчанию)\n" +
                                    "\t 2: создать сотрудника с заданными параметрами\n" +
                                    "\t 3: узнать ФИО сотрудника\n" +
                                    "\t 4: узнать дату рождения сотрудника\n" +
                                    "\t 5: узнать возраст сотрудника\n" +
                                    "\t 6: узнать должность сотрудника\n" +
                                    "\t 7: узнать опыт работы сотрудника\n" +
                                    "\t 8: изменить должность сотрудника\n");
                int key = ReadKey();
                string post;

                switch (key)
                {
                    case 1:
                        {
                            empl = new Employee();
                            Console.WriteLine("Сотрудник со стандартными параметрами задан");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Введите фамилию сотрудника");
                            string surname = Console.ReadLine();
                            Console.WriteLine("Введите имя сотрудника");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите отчество сотрудника");
                            string patronymic = Console.ReadLine();
                            Console.WriteLine("Введите год рождения сотрудника");
                            int y = ReadKey();
                            Console.WriteLine("Введите месяц рождения сотрудника");
                            int m = ReadKey();
                            Console.WriteLine("Введите день рождения сотрудника");
                            int d = ReadKey();
                            Console.WriteLine("Введите должность сотрудника");
                            post = Console.ReadLine();
                            Console.WriteLine("Введите год начала работы сотрудника");
                            int yw = ReadKey();
                            Console.WriteLine("Введите месяц начала работы сотрудника");
                            int mw = ReadKey();
                            Console.WriteLine("Введите день начала работы сотрудника");
                            int dw = ReadKey();

                            try
                            {
                                empl = new Employee(surname, name, patronymic, new DateTime(y, m, d), post, new DateTime(yw, mw, dw));
                                Console.WriteLine("человек с данными параметрами создан");
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Неверно введена дата рождения");
                            }

                            break;
                        }
                    case 3:
                        Console.WriteLine("ФИО сотрудника: {0} {1} {2}", empl.Surname, empl.Name, empl.Patronymic);
                        break;
                    case 4:
                        {
                            DateTime date = empl.Birthdate;
                            Console.WriteLine("Дата рождения сотрудника {0}.{1}.{2} (dd.mm.yyyy)", date.Day, date.Month, date.Year);
                            break;
                        }
                    case 5:
                        Console.WriteLine("Возраст сотрудника {0}", empl.Age);
                        break;
                    case 6:
                        Console.WriteLine("Должность сотрудника {0}", empl.Post);
                        break;
                    case 7:
                        Console.WriteLine("Опыт работы сотрудника {0}", empl.Experience);
                        break;
                    case 8:
                        {
                            Console.WriteLine("Введите новую должность сотрудника");
                            empl.Post = Console.ReadLine();
                            Console.WriteLine("Новая должность сотрудника {0} с опытом работы {1}", empl.Post, empl.Experience);
                        }
                        break;
                    default:
                        Console.WriteLine("Выбранного пункта меню не существет");
                        break;
                }

                Console.WriteLine("Желаете продолжить?(y/n - н/т)");
                continWork = Console.ReadLine();
                Console.WriteLine();
            }
            while (continWork.Equals("y") || continWork.Equals("н"));
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
