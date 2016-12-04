namespace Mikhalev_Nikolay_Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            DinamicArray<string> dinArr = new DinamicArray<string>();
            string cointWork;

            do
            {
                Console.Clear();
                Console.Write("Выберите что хотите сделать с динамическим массивом:\n" +
                                    "\t 1: создать пустой массив с длиной по умолчанию(создан по умолчанию)\n" +
                                    "\t 2: создать массив с заданным числом элементов\n" +
                                    "\t 3: создать массив из списка\n" +
                                    "\t 4: добавить в конец массива один элемент\n" +
                                    "\t 5: добавить в конец массива содержимое списка\n" +
                                    "\t 6: удалить желаемый элемент\n" +
                                    "\t 7: добавить элемент в указанную позицию\n" +
                                    "\t 8: получение длины массива\n" +
                                    "\t 9: получение колличества элементво в массиве\n" +
                                    "\t 0: перебрать массив в цикле foreach\n");//выводит весь массив а не только нужные границы
                int key = ReadKey();
                string str;
                List<string> list;
                int l;

                switch (key)
                {
                    case 1:
                        {
                            dinArr = new DinamicArray<string>();
                            Console.WriteLine("Новый пустой массив создан");
                            break;
                        }
                    case 2:
                        {
                            l = ReadKey();
                            dinArr = new DinamicArray<string>(l);
                            Console.WriteLine("Новый массив длиной {0} создан", l > 0 ? l : 8);
                            break;
                        }
                    case 3:
                        {
                            list = GenerateList();

                            dinArr = new DinamicArray<string>(list);
                            Console.WriteLine("Новый массив из списка создан");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Введите элемент, который хотите добавить в массив");
                            dinArr.Add(Console.ReadLine());
                            Console.WriteLine("Элемент добавлен в массив");
                            break;
                        }
                    case 5:
                        {
                            list = GenerateList();
                            dinArr.AddRange(list);
                            Console.WriteLine("Список добавлен в массив");
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Введите элемент, который хотете удалить из массива");
                            str = Console.ReadLine();

                            if (dinArr.Remove(str))
                            {
                                Console.WriteLine("элемент {0} удален из массива", str);
                            }
                            else
                            {
                                Console.WriteLine("элемента {0} в массиве нет", str);
                            }
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Введите элемент, который хотите добавить в массив");
                            str = Console.ReadLine();
                            Console.WriteLine("Введите на какую позицию вы хотите его добавить");
                            l = ReadKey();

                            try
                            {
                                if (dinArr.Insert(str, l))
                                {
                                    Console.WriteLine("Элемент добавлен в массив");
                                }
                                else
                                {
                                    Console.WriteLine("Элемент не добавлен в массив");
                                }
                            }
                            catch(ArgumentOutOfRangeException e)
                            {
                                Console.WriteLine("выберете позицию в пределах массива");
                            }

                            break;
                        }
                    case 8:
                        Console.WriteLine("длина массива равана {0}", dinArr.Length);
                        break;
                    case 9:
                        Console.WriteLine("колиичесво элементов в массиве {0}", dinArr.Capacity);
                        break;
                    case 0:
                        {
                            Console.WriteLine("Массив содержит:");

                            foreach (string elem in dinArr)
                            {
                                Console.WriteLine(elem);
                            }
                            break;
                        }
                    default:
                        Console.WriteLine("Выбранного пункта меню не существует");
                        break;
                }

                Console.WriteLine("Желаете повторить?(y/n - н/т)");
                cointWork = Console.ReadLine();
            }
            while (cointWork.Equals("y") || cointWork.Equals("н"));
        }

        private static int ReadKey()
        {
            int key;

            while (!int.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Данные введены не верно, повторите ввод");
            }

            return key;
        }

        private static List<string> GenerateList()
        {
            List<string> list = new List<string>();

            while (true)
            {
                Console.WriteLine("Введите слово или end(утв) для завершения, если вводите не в первый раз");
                string str = Console.ReadLine();

                if (list.Count != 0 && (str.Equals("end") || str.Equals("утв")))
                {
                    break;
                }

                list.Add(str);
            }

            return list;
        }
    }
}
