namespace Mikhalev_Nikolay_Task1
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string cointWork;

            do
            {
                List<string> list = new List<string>();
                Console.Clear();
                Console.WriteLine("Задайте список людей");

                while (true)
                {
                    Console.WriteLine("Введите человека или end(утв) для завершения (при попытке сразу выйти параметр \nбудет считаться именем)");
                    string name = ReadKey();

                    if (list.Count != 0 && (name.Equals("end") || name.Equals("утв")))
                    {
                        break;
                    }

                    list.Add(name);
                }

                Console.Clear();
                Console.WriteLine("Список людей:");
                PrintList(list);
                int pos = 1;

                while (list.Count > 1)
                {
                    bool endElem = false;

                    if (pos + 1 == list.Count)
                    {
                        endElem = true;
                    }

                    Console.WriteLine();
                    Console.WriteLine("{0} выбыл", list[pos]);
                    list.RemoveAt(pos);
                    pos++;
                    Console.WriteLine("Остались:");
                    PrintList(list);

                    if (pos >= list.Count && !endElem)
                    {
                        pos = 0;
                    }

                    if (pos >= list.Count && endElem)
                    {
                        pos = 1;
                    }
                }
                
                Console.WriteLine("Остался {0}", list[0]);
                Console.WriteLine("Желаете повторить?(y/n - н/т)");
                cointWork = Console.ReadLine();
            }
            while (cointWork.Equals("y") || cointWork.Equals("н"));
        }

        private static void PrintList<T>(List<T> l)
        {
            foreach (T elem in l)
            {
                Console.WriteLine(elem);
            }
        }

        private static string ReadKey()
        {
            string key;

            do
            {
                key = Console.ReadLine();

                if (key.Equals(string.Empty))
                {
                    Console.WriteLine("Данные введены не верно, повторите ввод");
                }
                else
                {
                    return key;
                }
            }
            while (true);
        }
    }
}
