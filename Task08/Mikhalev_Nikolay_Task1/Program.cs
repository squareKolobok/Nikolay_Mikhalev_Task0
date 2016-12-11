namespace Mikhalev_Nikolay_Task1
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double[] doubleArr;
            int[] intArr;
            string[] strArr;
            string continWork;

            do
            {
                Console.Clear();
                Console.Write("Выберите что хотите сделать:\n" +
                                    "\t 1: заполнить массив типа double и узнать его сумму\n" +
                                    "\t 2: заполнить массив типа integer и узнать его сумму\n" +
                                    "\t 3: заполнить массив типа string и узнать его сумму\n");
                int key = IntReadKey();
                int n;

                switch (key)
                {
                    case 1:
                        {
                            doubleArr = CreateArr<double>(DoubleReadKey);
                            Console.WriteLine("Сумма элементов массива равна {0}", doubleArr.SumElementsInArray());
                            break;
                        }
                    case 2:
                        {
                            intArr = CreateArr<int>(IntReadKey);
                            Console.WriteLine("Сумма элементов массива равна {0}", intArr.SumElementsInArray());
                            break;
                        }
                    case 3:
                        {
                            strArr = CreateArr<string>(Console.ReadLine);
                            Console.WriteLine("Сумма элементов массива равна {0}", strArr.SumElementsInArray());
                            break;
                        }
                    default:
                        Console.WriteLine("Выбранного пункта меню не существет");
                        break;
                }

                Console.WriteLine("Желаете повторить?(y/n - н/т)");
                continWork = Console.ReadLine();
                Console.WriteLine();
            }
            while (continWork == "y" || continWork == "н");
        }

        private static int IntReadKey()
        {
            int key;

            while (!int.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Данные введены не верно, повторите ввод");
            }

            return key;
        }

        private static double DoubleReadKey()
        {
            double key;

            while (!double.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Данные введены не верно, повторите ввод");
            }

            return key;
        }

        private static T[] CreateArr<T>(Func<T> read)
        {
            Console.WriteLine("Введите размер массива");
            int n = IntReadKey();
            T[] Arr = new T[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите {0} элемент массива", i + 1);
                Arr[i] = read();
            }

            return Arr;
        }
    }
}
