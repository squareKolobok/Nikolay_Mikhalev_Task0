namespace Mikhalev_Nikolay_Task3
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string continWork;
            Stack<Figure> figures = new Stack<Figure>();

            do
            {
                Console.Clear();
                Console.WriteLine("Выберите пункт меню:\n" +
                                    "\t 1: создать линию\n" +
                                    "\t 2: создать окружность\n" +
                                    "\t 3: создать прямоугольник\n" +
                                    "\t 4: создать круг\n" +
                                    "\t 5: создать кольцо\n" +
                                    "\t 6: вывести все фигуры на экран");
                int key;

                while (!(int.TryParse(Console.ReadLine(), out key) && key > 0))
                {
                    Console.WriteLine("Данные введены не верно, повторите ввод");
                }
                Coord p1, p2;

                switch (key)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите точку начала x линии");
                            p1.x = ReadKey();
                            Console.WriteLine("Введите точку начала y линии");
                            p1.y = ReadKey();
                            Console.WriteLine("Введите точку конца x линии");
                            p2.x = ReadKey();
                            Console.WriteLine("Введите точку конца x линии");
                            p2.y = ReadKey();
                            figures.Push(new Line(p1, p2));
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Введите точку центра окружности x");
                            p1.x = ReadKey();
                            Console.WriteLine("Введите точку центра окружности y");
                            p1.y = ReadKey();
                            Console.WriteLine("Введите точку x лежащую на окружности");
                            p2.x = ReadKey();
                            Console.WriteLine("Введите точку y лежащую на окружности");
                            p2.y = ReadKey();
                            figures.Push(new Circum(p1, p2));
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Введите точку x левого нижнего угла квадрата");
                            p1.x = ReadKey();
                            Console.WriteLine("Введите точку y левого нижнего угла квадрата");
                            p1.y = ReadKey();
                            Console.WriteLine("Введите точку x правого верхнего угла квадрата");
                            p2.x = ReadKey();
                            Console.WriteLine("Введите точку y правого верхнего угла квадрата");
                            p2.y = ReadKey();
                            figures.Push(new Rect(p1, p2));
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Введите точку x центра круга");
                            p1.x = ReadKey();
                            Console.WriteLine("Введите точку y центра круга");
                            p1.y = ReadKey();
                            Console.WriteLine("Введите точку x лежащую на границе круга");
                            p2.x = ReadKey();
                            Console.WriteLine("Введите точку y лежащую на границе круга");
                            p2.y = ReadKey();
                            figures.Push(new Circle(p1, p2));
                            break;
                        }
                    case 5:
                        {
                            Coord p3;
                            Console.WriteLine("Введите точку x центра кольца");
                            p1.x = ReadKey();
                            Console.WriteLine("Введите точку y центра кольца");
                            p1.y = ReadKey();
                            Console.WriteLine("Введите точку x лежащую на границе внешнего круга");
                            p2.x = ReadKey();
                            Console.WriteLine("Введите точку y лежащую на границе внешнего круга");
                            p2.y = ReadKey();
                            Console.WriteLine("Введите точку x лежащую на границе внутреннего круга");
                            p3.x = ReadKey();   
                            Console.WriteLine("Введите точку y лежащую на границе внутреннего круга");
                            p3.y = ReadKey();
                            figures.Push(new Ring(p1, p2, p3));
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Все получиившиеся фигуры:");

                            while (figures.Count > 0)
                                figures.Pop().WriteRes();

                            break;
                        }
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
