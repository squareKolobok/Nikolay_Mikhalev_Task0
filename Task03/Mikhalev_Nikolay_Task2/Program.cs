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
                Console.Write("Введите первую строку: ");
                string str1 = Console.ReadLine();
                Console.Write("Введите вторую строку: ");
                string str2 = Console.ReadLine();
                int length = str1.Length;

                for (int i = 0; i < length; i++)
                {
                    if (str2.Contains(str1[i] + string.Empty))
                    {
                        str1 = str1.Insert(i, str1[i] + string.Empty);
                        i++;
                        length++;
                    }
                }

                Console.WriteLine("Результирующая срока: {0}", str1);
                Console.WriteLine("Желаете повторить?(y/n - н/т)");
                continWork = Console.ReadLine();
            }
            while (continWork == "y" || continWork == "н");
        }
    }
}
