namespace Mikhalev_Nikolay_Task1
{
    using System;

    internal class SortString
    {
        /// <summary>
        /// отсортированный массив строк
        /// </summary>
        private string[] arr;

        /// <summary>
        /// конструктор класса сортировки строк
        /// </summary>
        /// <param name="noSortArr">не отсортированный массив строк</param>
        public SortString(string[] noSortArr)
        {
            arr = noSortArr;
        }

        /// <summary>
        /// сортировка строк по нужному методу
        /// </summary>
        /// <param name="comp">метод сортировки</param>
        public void Sort(Func<string, string, bool> comp)
        {
            if (arr.Length > 0)
            {
                int length = arr.Length;

                for (int begin = 0; begin < length; begin++)
                {
                    int iMin = begin;

                    for (int i = begin; i < length; i++)

                        if (comp(arr[i], arr[iMin]))
                        {
                            iMin = i;
                        }

                    string b = arr[begin];
                    arr[begin] = arr[iMin];
                    arr[iMin] = b;
                }
            }
        }

        /// <summary>
        /// выводит отсортированный массив
        /// </summary>
        public void PrintArr()
        {
            foreach (string val in arr)
            {
                Console.Write("{0} ", val);
            }

            Console.WriteLine();
        }
    }
}