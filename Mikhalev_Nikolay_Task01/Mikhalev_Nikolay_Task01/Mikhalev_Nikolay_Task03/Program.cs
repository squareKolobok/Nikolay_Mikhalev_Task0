using System;

namespace Mikhalev_Nikolay_Task03
{
    class Program
    {
        static void Main()
        {
            string continWork;
            do
            {
                int N;
                string result = "*";
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Введите колличество строк N");
                    if (int.TryParse(Console.ReadLine(), out N))
                        break;
                    else
                        Console.WriteLine("Неверно введено N, повторите ввод");
                }
                for (int i = 0; i < N; i++)
                {
                    for (int j = 1; j < N - i; j++)
                        Console.Write(" ");
                    Console.WriteLine(result);
                    result += "**";
                }
                Console.WriteLine("Желаете повторить?(y/n - н/т)");
                continWork = Console.ReadLine();
            } while (continWork == "y" || continWork == "н");
        }
    }
}
