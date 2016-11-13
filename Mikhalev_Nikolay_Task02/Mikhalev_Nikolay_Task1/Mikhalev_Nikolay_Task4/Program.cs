using System;

namespace Mikhalev_Nikolay_Task4
{
    class Program
    {
        static void Main()
        {
            string continWork;
            do
            {
                Console.Clear();
                Console.WriteLine("Введите высоту массива");
                int hight = ReadKey();
                Console.WriteLine("Введите ширину массива");
                int width = ReadKey();
                Random r = new Random();
                int[,] arr = new int[hight, width];
                for (int i = 0; i < hight; i++)
                    for (int j = 0; j < width; j++)
                            arr[i, j] = r.Next(-1000, 1000);
                Console.WriteLine("Массив имеет вид:");
                for (int i = 0; i < hight; i++)
                {
                    for (int j = 0; j < width; j++)
                        Console.Write("{0} ", arr[i, j]);
                    Console.WriteLine();
                }
                int s = 0;
                for (int i = 0; i < hight; i += 2)
                    for (int j = 0; j < width; j += 2)
                        s += arr[i, j];
                Console.WriteLine("Сумма всех элементов на четных позициях равна {0}",s);
                Console.WriteLine("Желаете продолжить?(y/n - н/т)");
                continWork = Console.ReadLine();
            } while (continWork == "y" || continWork == "н");
        }

        static int ReadKey()
        {
            int key;
            while (true)
            {
                string k = Console.ReadLine();
                if (int.TryParse(k, out key) && key > 0)
                    break;
                else
                    Console.WriteLine("Данные введены не верно, повторите ввод");
            }
            return key;
        }
    }
}
