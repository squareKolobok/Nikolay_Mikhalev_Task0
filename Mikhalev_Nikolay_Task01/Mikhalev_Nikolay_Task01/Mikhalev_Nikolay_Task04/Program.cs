using System;

namespace Mikhalev_Nikolay_Task04
{
    class Program
    {
        static void Main()
        {
            string continWork;
            do
            {
                int N;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Введите колличество треугольников N");
                    if (int.TryParse(Console.ReadLine(), out N))
                        break;
                    else
                        Console.WriteLine("Неверно введено N, повторите ввод");
                }
                for (int i = 0; i < N; i++)
                    WriteTriangle(i, N);
                Console.WriteLine("Желаете повторить?(y/n - н/т)");
                continWork = Console.ReadLine();
            } while (continWork == "y" || continWork == "н");
        }

        static void WriteTriangle(int count, int N)
        {
            string result = "*";
            for (int i = 0; i < count; i++)
            {
                for (int j = 1; j < N - i; j++)
                    Console.Write(" ");
                Console.WriteLine(result);
                result += "**";
            }
        }
    }
}
