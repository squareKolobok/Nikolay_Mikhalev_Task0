namespace Mikhalev_Nikolay_Task1
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string continWork;
            Round round = new Round();

            do
            {
                Console.Clear();
                Console.Write("Выберите что хотите сделать с кругом:\n" +
                                    "\t 1: создать круг со стандартными параметрами (задан по умолчанию)\n" +
                                    "\t 2: создать круг с заданным радиусом\n" +
                                    "\t 3: создать круг с заданным центром и радиусом\n" +
                                    "\t 4: посмотреть периметр круга\n" +
                                    "\t 5: посмотреть площадь круга\n");
                int key;

                while (!(int.TryParse(Console.ReadLine(), out key) && key > 0))
                {
                    Console.WriteLine("Данные введены не верно, повторите ввод");
                }

                double x, y, r;

                switch (key)
                {
                    case 1:
                        {
                            round = new Round();
                            Console.WriteLine("круг со стандартными параметрами задан(x=0,y=0,r=1)");
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Радиус круга r=");
                            r = ReadKey();
                            round = new Round(r);
                            Console.WriteLine("круг с r={0} задан", r > 0 ? r : 1);
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Введите точку абсцисс x=");
                            x = ReadKey();
                            Console.Write("Введите точку ординат y=");
                            y = ReadKey();
                            Console.Write("Радиус круга r=");
                            r = ReadKey();
                            round = new Round(x, y, r);
                            Console.WriteLine("круг с параметрами x={0}, y={1}, r={2} задан", x, y, r > 0 ? r : 1);
                            break;
                        }
                    case 4:
                        Console.WriteLine("Периметр круга равен {0}", round.Perimeter());
                        break;
                    case 5:
                        Console.WriteLine("Площадь круга равна {0}", round.Area());
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

            while (!double.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Данные введены не верно, повторите ввод");
            }

            return key;
        }
    }
}
