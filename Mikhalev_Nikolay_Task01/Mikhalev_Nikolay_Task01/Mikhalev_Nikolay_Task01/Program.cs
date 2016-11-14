using System;

namespace Mikhalev_Nikolay_Task01
{
    class Program
    {
        static void Main()
        {
            string continWork;
            do
            {
                double a, b;
                while (true)//todo при некорректном вводе значений нужно выводить соответствующие сообщения об ошибках.
                {
                    Console.Clear();
                    Console.WriteLine("Введите размеры прямоугольника a и b через Enter");
                    if (double.TryParse(Console.ReadLine(), out a) && double.TryParse(Console.ReadLine(), out b))
                        if (a > 0 && b > 0) break;
                        else
                            Console.WriteLine("Данные введены неверно, повторите ввод");
                }
                Console.WriteLine("площадь прямоугольника ={0}", a * b);
                Console.WriteLine("Желаете повторить?(y/n - н/т)");
                continWork = Console.ReadLine();
            } while (continWork == "y" || continWork == "н");
        }
    }
}
