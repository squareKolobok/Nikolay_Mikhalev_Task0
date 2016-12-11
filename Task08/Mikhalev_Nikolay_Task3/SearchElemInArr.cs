namespace Mikhalev_Nikolay_Task3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SearchElemInArr
    {
        public double[] Arr { get; private set; }

        public SearchElemInArr(double[] arr)
        {
            this.Arr = arr;
        }

        /// <summary>
        /// поиск положительных элементов напрямую
        /// </summary>
        /// <returns>массив с элементами которые больши или равны 0</returns>
        public double[] DirectlySearch()
        {
            List<double> list = new List<double>();

            for(int i = 0; i < Arr.Length; i++)
            {
                if (Arr[i] >= 0)
                {
                    list.Add(Arr[i]);
                }
            }

            return list.ToArray(); 
        }

        public double[] DelegateSearch(Func<double, bool> search)
        {
            List<double> list = new List<double>();

            for (int i = 0; i < Arr.Length; i++)
            {
                if (search(Arr[i]))
                {
                    list.Add(Arr[i]);
                }
            }

            return list.ToArray();
        }

        public double[] ListSearch()
        {
            var posElems = from item in Arr
                           where item >= 0
                           select item;
            return posElems.ToArray();
        }

        public void WriteArr(double[] arr)
        {
            foreach(double elem in arr)
            {
                Console.Write("{0} ", elem);
            }

            Console.WriteLine();
        }
    }
}