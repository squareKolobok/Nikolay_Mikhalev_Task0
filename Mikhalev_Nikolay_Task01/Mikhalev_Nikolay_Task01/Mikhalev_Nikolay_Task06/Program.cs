using System;

namespace Mikhalev_Nikolay_Task06
{
    class Program
    {
        static void Main()
        {
            string Modifi = "";
            do
            {
                Console.Clear();
                Console.Write("Параметры надписи: ");
                int lengthString = Modifi.Length;
                if (lengthString > 0)
                {
                    for (int i = 0; i < Modifi.Length; i++)
                        switch (Modifi[i])
                        {
                            case '1':
                                Console.Write(" Bold");
                                break;
                            case '2':
                                Console.Write(" Italic");
                                break;
                            case '3':
                                Console.Write(" Inderlin");
                                break;
                        }
                }
                else
                    Console.Write(" None");
                Console.WriteLine();
                string a;
                while (true)
                {
                    Console.WriteLine("Введите:\n" +
                                        "\t 1: bold\n" +
                                        "\t 2: italic\n" +
                                        "\t 3: underline");
                    a = Console.ReadLine();
                    if (a.Equals("1") || a.Equals("2") || a.Equals("3")) break;
                }
                int ind = Modifi.IndexOf(a);
                if (ind != -1)
                    Modifi = Modifi.Remove(ind, 1);
                else
                    Modifi += a;
            } while (true);
        }
    }
}
