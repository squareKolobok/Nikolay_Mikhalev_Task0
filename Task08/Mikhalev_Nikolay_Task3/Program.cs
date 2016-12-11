namespace Mikhalev_Nikolay_Task3
{
    using System;
    using System.Diagnostics;

    public class Program
    {
        public static void Main()
        {
            string continWork;

            do
            {
                Console.Clear();
                SearchElemInArr search = new SearchElemInArr(CreateArr());
                Stopwatch sw = new Stopwatch();
                Console.Clear();

                Console.WriteLine("Массив выглядит:");
                search.WriteArr(search.Arr);
                Console.WriteLine();

                sw.Start();
                Console.WriteLine("Массив прямого перебора:");
                search.WriteArr(search.DirectlySearch());
                sw.Stop();
                WriteTime(sw, "прямом переборе");

                sw.Restart();
                Console.WriteLine("Массив с перебором при помощи передающегося делегата");
                search.WriteArr(search.DelegateSearch(CompElem));
                sw.Stop();
                WriteTime(sw, "помощи передающегося делегата");

                sw.Restart();
                Console.WriteLine("Массив с перебором при помощи анонимного делегата");
                search.WriteArr(search.DelegateSearch(delegate (double elem)
                {
                    return elem >= 0;
                }));
                sw.Stop();
                WriteTime(sw, "помощи анонимного делегата");

                sw.Restart();
                Console.WriteLine("Массив с перебором при помощи лямбда-выражений");
                search.WriteArr(search.DelegateSearch(x => x >= 0));
                sw.Stop();
                WriteTime(sw, "помощи лямбда-выражений");

                sw.Restart();
                Console.WriteLine("Массив с перебором при LINQ-запросов");
                search.WriteArr(search.ListSearch());
                sw.Stop();
                WriteTime(sw, "LINQ-запросе");

                Console.WriteLine("Желаете повторить?(y/n - н/т)");
                continWork = Console.ReadLine();
                Console.WriteLine();
            }
            while (continWork == "y" || continWork == "н");
        }

        private static bool CompElem(double elem)
        {
            return elem >= 0;
        }

        private static T ReadKey<T>(Loop<T> loop)
        {
            T key;
            
            while (loop(out key))
            {
                Console.WriteLine("Данные введены не верно, повторите ввод");
            }

            return key;
        }

        private static double[] CreateArr()
        {
            Console.WriteLine("Введите размер массива");

            int n = ReadKey<int>(delegate (out int key)
            {
                return (!int.TryParse(Console.ReadLine(), out key));
            });

            double[] Arr = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите {0} элемент массива", i + 1);

                Arr[i] = ReadKey<double>(delegate (out double key)
                {
                    return (!double.TryParse(Console.ReadLine(), out key));
                });
            }

            return Arr;
        }

        private static void WriteTime(Stopwatch sw, string name)
        {
            Console.WriteLine("Времени затрачено на работу при {0}", name);
            Console.WriteLine("в миллисекундах: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("в тактах таймера: {0}", sw.ElapsedTicks);
            Console.WriteLine();

        }

        private delegate bool Loop<T>(out T key);
    }
}
