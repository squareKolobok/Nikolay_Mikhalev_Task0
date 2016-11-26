namespace Mikhalev_Nikolay_Task2
{
    using System;

    class Program
    {
        static void Main()
        {
            string continWork;
            Ring ring = new Ring();
            do
            {
                Console.Clear();
                Console.Write("Выберите что хотите сделать с кольцом:\n" +
                                    "\t 1: создать кольцо со стандартными параметрами (задано по умолчанию)\n" +
                                    "\t 2: создать кольцо с заданными радиусами\n" +
                                    "\t 3: создать кольцо с заданным центром и радиусами\n" +
                                    "\t 4: посмотреть периметр кольца\n" +
                                    "\t 5: посмотреть площадь кольца\n");
                int key;

                while (!(int.TryParse(Console.ReadLine(), out key) && key > 0))
                {
                    Console.WriteLine("Данные введены не верно, повторите ввод");
                }

                double x, y, interR, exterR;

                switch (key)
                {
                    case 1:
                        {
                            ring = new Ring();
                            Console.WriteLine("кольцо со стандартными параметрами задано(x=0, y=0, interR=0.5, exterR=1)");
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Радиус внутренний радиус кольца interR=");
                            interR = ReadKey();
                            Console.Write("Радиус внешний радиус кольца exterR=");
                            exterR = ReadKey();
                            ring = new Ring(interR, exterR);
                            Console.WriteLine("кольцо с interR={0} и exterR={1} задано", 
                                (interR > 0) && (interR < exterR) ? interR : 0.5, 
                                exterR > 0 ? exterR : 1);
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Введите точку абсцисс x=");
                            x = ReadKey();
                            Console.Write("Введите точку ординат y=");
                            y = ReadKey();
                            Console.Write("Радиус внутренний радиус кольца interR=");
                            interR = ReadKey();
                            Console.Write("Радиус внешний радиус кольца exterR=");
                            exterR = ReadKey();
                            ring = new Ring(x, y, interR, exterR);
                            Console.WriteLine("кольцо с параметрами x={0}, y={1}, interR={2}, exterR={3} задано", x, y, 
                                (interR > 0) && (interR < exterR) ? interR : 0.5, 
                                exterR > 0 ? exterR : 1);
                            break;
                        }
                    case 4:
                        Console.WriteLine("Периметр кольца равен {0}", ring.Perimeter());
                        break;
                    case 5:
                        Console.WriteLine("Площадь кольца равна {0}", ring.Area());
                        break;
                    default:
                        Console.WriteLine("Выбранного пункта меню не существет");
                        break;
                }

                Console.WriteLine("Желаете продолжить?(y/n - н/т)");
                continWork = Console.ReadLine();
                Console.WriteLine();
            }
            while (continWork.Equals("y") || continWork.Equals("н"));
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
