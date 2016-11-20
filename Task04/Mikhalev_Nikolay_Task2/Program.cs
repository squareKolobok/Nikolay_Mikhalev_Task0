namespace Mikhalev_Nikolay_Task2
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string continWork;
            Triangle tr = new Triangle();

            do
            {
                Console.Clear();
                Console.Write("Выберите что хотите сделать с треугольником:\n" +
                                    "\t 1: создать треугольник со стандартными параметрами(задан по умолчанию)\n" +
                                    "\t 2: создать треугольник с заданными параметрами\n" +
                                    "\t 3: посмотреть периметр треугольника\n" +
                                    "\t 4: посмотреть площадь треугольника\n");
                string key = Console.ReadLine();
                double a, b, c;

                switch (key)
                {
                    case "1":
                        tr = new Triangle();
                        Console.WriteLine("треугольник со стандартными параметрами задан (a=1, b=1, c=1)");
                        break;
                    case "2":
                        Console.Write("Введите сторону a=");
                        a = ReadKey();
                        Console.Write("Введите сторону b=");
                        b = ReadKey();
                        Console.Write("Введите сторону c=");
                        c = ReadKey();
                        tr = new Triangle(a, b, c);
                        Console.WriteLine("треугольник задан исходя из введеных значений");
                        break;
                    case "3":
                        Console.WriteLine("Периметр треугольника равен {0}", tr.Perimeter());
                        break;
                    case "4":
                        Console.WriteLine("Площадь треугольника равна {0}", tr.Area());
                        break;
                    default:
                        Console.WriteLine("Выбранного пункта меню не существет");
                        break;
                }

                Console.WriteLine("Желаете продолжить?(y/n - н/т)");
                continWork = Console.ReadLine();
                Console.WriteLine();
            }
            while (continWork == "y" || continWork == "н");
        }

        private static double ReadKey()
        {
            double key;

            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out key) && key > 0)
                {
                    break;
                }

                Console.WriteLine("Данные введены не верно, повторите ввод");
            }

            return key;
        }
    }
}
