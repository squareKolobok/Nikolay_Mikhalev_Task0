namespace Mikhalev_Nikolay_Task2
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string continWork;

            do
            {
                Console.Clear();

                Console.WriteLine("Введите строку, которую хотите проверить является ли она положительным числом");
                string str = Console.ReadLine();
                Console.WriteLine("строка {0} {1}является положительным числом", str, str.IsPositivNumber() ? string.Empty : "не ");

                Console.WriteLine("Желаете повторить?(y/n - н/т)");
                continWork = Console.ReadLine();
                Console.WriteLine();
            }
            while (continWork == "y" || continWork == "н");
        }
    }
}
