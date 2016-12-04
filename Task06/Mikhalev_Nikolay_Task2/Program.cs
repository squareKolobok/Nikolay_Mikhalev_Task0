namespace Mikhalev_Nikolay_Task2
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string cointWork;

            do
            {
                List<string> list = new List<string>();
                Console.Clear();
                int pos = 0;
                Console.WriteLine("Введите текст");
                string text = Console.ReadLine();

                do
                {
                    char[] separator = { ' ', '.' };
                    int next = text.IndexOfAny(separator, pos);
                    string str = text.Substring(pos, next != -1 ? next - pos : text.Length - pos);
                    pos = next + 1;

                    if (!str.Equals(string.Empty))
                    {
                        list.Add(str);
                    }
                }
                while (pos != 0);

                if (list.Count > 0)
                {
                    list.Sort();
                    pos = 1;
                    int count = 1;
                    string elem = list[0];

                    while (pos < list.Count)
                    {
                        if (string.Compare(elem, list[pos], true) == 0)
                        {
                            count++;
                        }
                        else
                        {
                            PrintElem(elem, count);
                            count = 1;
                            elem = pos < list.Count ? list[pos] : string.Empty;
                        }

                        pos++;
                    }

                    PrintElem(elem, count);           
                }

                Console.WriteLine("Желаете повторить?(y/n - н/т)");
                cointWork = Console.ReadLine();
            }
            while (cointWork.Equals("y") || cointWork.Equals("н"));
        }

        private static void PrintElem(string elem, int count)
        {
            Console.WriteLine("{0} входит в данный текст {1} раз", elem, count);
        }
    }
}
