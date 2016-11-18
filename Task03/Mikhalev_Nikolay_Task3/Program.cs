namespace Mikhalev_Nikolay_Task3
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            string continWork;

            do
            {
                Stopwatch sw = new Stopwatch();
                int N = 1000;
                string str = string.Empty;
                StringBuilder sb = new StringBuilder();
                sw.Start();

                for (int i = 0; i < N; i++)
                {
                    str += "*";
                }

                sw.Stop();
                WriteTime(sw, "String");
                sw.Reset();
                sw.Start();

                for (int i = 0; i < N; i++)
                {
                    sb.Append("*");
                }

                sw.Stop();
                WriteTime(sw, "StingBuilder");
                Console.WriteLine("Желаете повторить?(y/n - н/т)");
                continWork = Console.ReadLine();
                Console.WriteLine();
            }
            while (continWork == "y" || continWork == "н");
        }

        private static void WriteTime(Stopwatch sw, string nameObj)
        {
            Console.WriteLine("Времени затрачено на работу с объектом {0}", nameObj);
            Console.WriteLine("в миллисекундах: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("в тактах таймера: {0}", sw.ElapsedTicks);
        }
    }
}
