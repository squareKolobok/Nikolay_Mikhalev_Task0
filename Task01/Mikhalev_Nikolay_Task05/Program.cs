using System;

namespace Mikhalev_Nikolay_Task05
{
    class Program
    {
        static void Main()
        {
            string continWork;
            do
            {
                Console.Clear();
                Console.Write("Сумма всех элементов меньше 1000, кратных 3 и 5 =");
                int result = SumArithmProgr(3, 333, 3) + SumArithmProgr(5, 199, 5) - SumArithmProgr(15, 66, 15);//todo предполагалось, что ты будешь использовать циклы, но ладно
                Console.WriteLine(result);
                Console.Write("Желаете повторить?(y/n - н/т)");
                continWork = Console.ReadLine();
            } while (continWork == "y" || continWork == "н");
        }

        static int SumArithmProgr(int a1, int n, int d)
        {
            return (2 * a1 + d * (n - 1)) * n / 2;
        }
    }
}
