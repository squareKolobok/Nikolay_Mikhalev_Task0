namespace Mikhalev_Nikolay_Task4
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string continWork;
            MyString str = new MyString();

            do
            {
                Console.Clear();
                Console.Write("Выберите что хотите сделать со строкой:\n" +
                                    "\t 1: создать пустую строку(задана по умолчанию)\n" +
                                    "\t 2: создать строку из введенного текста\n" +
                                    "\t 3: сложить имеющуюся строку с новой\n" +
                                    "\t 4: найти позицию указанного элемента\n" +
                                    "\t 5: сравнить две строки\n" +
                                    "\t 6: вывести строку\n");
                string key = Console.ReadLine();
                char[] charArr;
                MyString str2;

                switch (key)
                {
                    case "1":
                        str = new MyString();
                        Console.WriteLine("Пустая строка создана");
                        break;
                    case "2":
                        Console.WriteLine("Введите новую строку");
                        charArr = Console.ReadLine().ToCharArray();
                        str = new MyString(charArr);
                        Console.WriteLine("Введенная строка создана");
                        break;
                    case "3":
                        Console.WriteLine("Введите новую строку");
                        charArr = Console.ReadLine().ToCharArray();
                        str2 = new MyString(charArr);
                        str += str2;
                        Console.WriteLine("Получившийся результат: {0}", str.ToString());
                        break;
                    case "4":
                        char a;

                        while (true)
                        {
                            Console.WriteLine("Введите символ позицию которого хотите найти (считывается только первый введенный символ)");
                            string s = Console.ReadLine();

                            if (s.Length > 0)
                            {
                                a = s[0];
                                break;
                            }

                            Console.WriteLine("Повторите ввод");
                        }

                        Console.WriteLine("Данный символ находится на {0} месте", str.IndexOf(a));
                        break;
                    case "5":
                        Console.WriteLine("Введите новую строку");
                        charArr = Console.ReadLine().ToCharArray();
                        str2 = new MyString(charArr);
                        Console.WriteLine("Данные строки {0}равны", str.Equals(str2) ? string.Empty : "не ");
                        break;
                    case "6":
                        Console.WriteLine("Хранящаяся строка: {0}", str.ToString());
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
    }
}
