using System;

namespace Mikhalev_Nikolay_Task2
{
    class Program
    {
        static void Main()
        {
            double h;
            string continWork;
            do
            {
                while (true)
                {
                    Console.Write("Введите действительное число h\nh=");
                    if (double.TryParse(Console.ReadLine(), out h))
                        break;
                    else
                        Console.Write("данные введены не правильно, повторите ввод \n");
                }
                double a = Math.Sqrt((Math.Abs(Math.Sin(8 * h)) + 17) / Math.Pow((1 - Math.Sin(4 * h) * Math.Cos(h * h + 18)), 2));
                double b = 1 - Math.Sqrt(3 / (3 + Math.Abs(Math.Tan(a * h * h) - Math.Sin(a * h))));
                double c = a * h * h * Math.Sin(b * h) + b * Math.Pow(h, 3) * Math.Cos(a * h);
                double d = b * b - 4 * a * c;
                Console.Write("a=" + Math.Round(a, 5) + " \n");
                Console.Write("b=" + Math.Round(b, 5) + " \n");
                Console.Write("c=" + Math.Round(c, 5) + " \n");
                Console.Write("Уравнение имеет вид: " + Math.Round(a, 5) + "*x^2+"
                                                      + Math.Round(b, 5) + "*x+"
                                                      + Math.Round(c, 5) + "=0 \n");
                Console.Write("Дискриминант D=" + Math.Round(d, 5) + " \n");
                if (d < 0)
                    Console.Write("Уравнение не имеет действительных корней \n");
                else if (d > 0)
                {
                    double x1 = (-b - Math.Sqrt(d)) / (2 * a);
                    double x2 = (-b + Math.Sqrt(d)) / (2 * a);
                    Console.Write("Уравнение имеет два действительных корня \nx1="
                        + Math.Round(x1, 5) + "\nx2=" + Math.Round(x2, 5) + "\n");
                }
                else
                {
                    double x = -b / (2 * a);
                    Console.Write("Уравнение имеет один действительный корень x=" + x + "\n");
                }
                Console.Write("Желаете повторить? (y / n) \n");
                continWork = Console.ReadLine();
            } while (continWork == "y" || continWork == "н");
        }
    }
}
