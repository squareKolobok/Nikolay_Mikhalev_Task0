namespace Mikhalev_Nikolay_Task1
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string continWork;

            do
            {
                Console.Clear();
                int countWords = 0;
                int length = 0;
                Console.WriteLine("Введите строку");
                string text = Console.ReadLine();
                bool word = false;
                int l = text.Length;//todo мог бы и сразу в цикле запросить длину текста, лишняя переменная

                for (int i = 0; i < l; i++)
                {
                    if (char.IsLetterOrDigit(text[i]))
                    {
                        length++;
                        word = true;
                    }
                    else if (word)
                    {
                        word = false;
                        countWords++;
                    }
                }

                if (word)
                {
                    countWords++;
                }

                Console.WriteLine("средняя длина слова равняется {0}", countWords > 0 ? (int)length / countWords : countWords);
                Console.WriteLine("Желаете повторить?(y/n - н/т)");
                continWork = Console.ReadLine();
            }
            while (continWork == "y" || continWork == "н");
        }
    }
}
