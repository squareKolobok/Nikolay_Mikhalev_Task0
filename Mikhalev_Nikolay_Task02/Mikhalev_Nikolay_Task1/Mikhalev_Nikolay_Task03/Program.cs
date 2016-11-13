using System;

namespace Mikhalev_Nikolay_Task3
{
    class Program
    {
        static void Main()
        {
            string continWork;
            do
            {
                Console.Clear();
                Console.WriteLine("Введите размер массива");
                int length = ReadKey();
                Random r = new Random();
                int[] arr = new int[length];
                for (int i = 0; i < length; i++)
                    arr[i] = r.Next(-1000, 1000);
                Console.WriteLine("Массив имеет вид:");
                for (int i = 0; i < length; i++)
                    Console.Write("{0} ", arr[i]);
                Console.WriteLine();
                int sum = 0;
                for (int i = 0; i < length; i++)
                    if (arr[i] > 0) sum += arr[i];
                Console.WriteLine("сумма всех неорицательных элементов равна {0}", sum);
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
