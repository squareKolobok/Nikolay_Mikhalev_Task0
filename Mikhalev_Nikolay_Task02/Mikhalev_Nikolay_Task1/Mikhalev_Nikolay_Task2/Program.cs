using System;


namespace Mikhalev_Nikolay_Task2
{
    class Program
    {

        static int hight;
        static int width;
        static int length;

        static void Main()//todo помним про форматирование? отступы перед условиями и циклами
        {
            string continWork;
            do
            {
                Console.Clear();
                Console.WriteLine("Введите высоту массива");
                hight = ReadKey();
                Console.WriteLine("Введите ширину массива");
                width = ReadKey();
                Console.WriteLine("Введите длину массива");
                length = ReadKey();
                Random r = new Random();
                int[,,] arr = new int[hight, width, length];
                for (int i = 0; i < hight; i++)
                    for (int j = 0; j < width; j++)
                        for (int k = 0; k < length; k++)
                            arr[i, j, k] = r.Next(-1000, 1000);
                Console.WriteLine("Массив имеет вид:");
                PrintMatr(arr);
                for (int i = 0; i < hight; i++)
                    for (int j = 0; j < width; j++)
                        for (int k = 0; k < length; k++)
                            if (arr[i, j, k] > 0) arr[i, j, k] = 0;
                Console.WriteLine("Массив после замены положительных числе на нули:");
                PrintMatr(arr);
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

        static void PrintMatr(int[,,] arr) {
            string str = "[";
            for (int i = 0; i < hight; i++)
            {
                str += "[";
                for (int j = 0; j < width; j++)
                {
                    str += "[";
                    for (int k = 0; k < length; k++)
                        str+=arr[i, j, k]+", ";
                    str = str.Remove(str.Length-2,2);
                    str += "], ";
                }
                str = str.Remove(str.Length - 2, 2);
                str += "], ";
            }
            str = str.Remove(str.Length - 2, 2);
            str += "]";
            Console.WriteLine(str);
        }
    }
}
