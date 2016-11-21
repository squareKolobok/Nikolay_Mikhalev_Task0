namespace Mikhalev_Nikolay_Task1
{
    using System;
    using System.Threading;

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
                string key = Console.ReadLine();
                double x, y, r;

                switch (key)//todo синтаксически неверное оформление оператора
                {
                    case "1"://todo если блок case содержит более одной строки, то обязательно брать их в фигурные скобки (для повышения удобства чтения кода)
                        round = new Round();
                        Console.WriteLine("круг со стандартными параметрами задан(x=0,y=0,r=1)");
                        break;
                    case "2":
                        Console.Write("Радиус круга r=");
                        r = ReadKey();
                        round = new Round(r);
                        Console.WriteLine("круг с r={0} задан", r > 0 ? r : 1);
                        break;
                    case "3":
                        Console.Write("Введите точку абсцисс x=");
                        x = ReadKey();
                        Console.Write("Введите точку ординат y=");
                        y = ReadKey();
                        Console.Write("Радиус круга r=");
                        r = ReadKey();
                        round = new Round(r);
                        Console.WriteLine("круг с параметрами x={0}, y={1}, r={2} задан", x, y, r > 0 ? r : 1);
                        break;
                    case "4":
                        Console.WriteLine("Периметр круга равен {0}", round.Perimeter());
                        break;
                    case "5":
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
