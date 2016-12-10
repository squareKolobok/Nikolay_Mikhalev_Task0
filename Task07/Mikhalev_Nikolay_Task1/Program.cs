namespace Mikhalev_Nikolay_Task1
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
                Console.Clear();
                SortString st;

                {
                    Console.WriteLine("Введите текст через пробел");
                    string text = Console.ReadLine();
                    int pos = 0;
                    List<string> list = new List<string>();

                    do
                    {
                        int next = text.IndexOf(' ', pos);
                        string str = text.Substring(pos, next != -1 ? next - pos : text.Length - pos);
                        pos = next + 1;

                        if (!str.Equals(string.Empty))
                        {
                            list.Add(str);
                        }
                    }
                    while (pos != 0);

                    st = new SortString(list.ToArray());
                }

                st.Sort(delegate(string s1, string s2)
                {
                    if (s1.Length < s2.Length)
                    {
                        return true;
                    }

                    if (s1.Length > s2.Length)
                    {
                        return false;
                    }

                    return string.Compare(s1, s2) < 0;
                });
                Console.WriteLine("Отсортированный массив выглядит:");
                st.PrintArr();
                Console.WriteLine("Желаете повторить?(y/n - н/т)");
                cointWork = Console.ReadLine();
            }
            while (cointWork.Equals("y") || cointWork.Equals("н"));
        }
    }
}
