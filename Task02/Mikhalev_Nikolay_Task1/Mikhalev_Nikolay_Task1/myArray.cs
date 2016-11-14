using System;

namespace Mikhalev_Nikolay_Task1
{
    internal class myArray
    {
        private int[] arr;
        private int length; 

        public myArray(int length) {
            arr = new int[length];
            this.length = length;
            Random r = new Random();
            for (int i = 0; i < length; i++)
                arr[i] = r.Next(-1000,1000);
        }

        public int Max() {
            int max = arr[0];
            for (int i = 0; i < length; i++)
                max = arr[i] > max ? arr[i] : max; 
            return max;
        }

        public int Min() {
            int min = arr[0];
            for (int i = 0; i < length; i++)
                min = arr[i] < min ? arr[i] : min;
            return min;
        }

        public void Sort() {
            int IMin = 0;
            for(int begin=0;begin<length;begin++) {
                IMin = begin;
                for (int i = begin; i <length; i++) 
                    if (arr[i] < arr[IMin]) IMin = i;
                int b = arr[begin];
                arr[begin] = arr[IMin];
                arr[IMin] = b;
            }
        }

        public void PrintArr() {
            for (int i = 0; i < length; i++)
                Console.Write("{0} ",arr[i]);
            Console.WriteLine();
        }
    }
}