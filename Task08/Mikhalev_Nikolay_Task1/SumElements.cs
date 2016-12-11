using System.Text;

namespace Mikhalev_Nikolay_Task1
{
    //как использовать обобщения, чтобы оно работало только с числами или любым объектом у которого определена операция + я не нашел
    public static class SumElements
    {
        /// <summary>
        /// считает сумму элементов массива
        /// </summary>
        /// <param name="param">массив типа double</param>
        /// <returns>сумма массива типа double</returns>
        public static double SumElementsInArray(this double[] param)
        {
            double sum = 0;

            foreach(double val in param)
            {
                sum += val;
            }

            return sum;
        }

        /// <summary>
        /// считает сумму элементов массива
        /// </summary>
        /// <param name="param">массив типа int</param>
        /// <returns>сумма массива типа int</returns>
        public static int SumElementsInArray(this int[] param)
        {
            int sum = 0;

            foreach (int val in param)
            {
                sum += val;
            }

            return sum;
        }

        /// <summary>
        /// считает сумму элементов массива
        /// </summary>
        /// <param name="param">массив типа string</param>
        /// <returns>сумма массива типа string</returns>
        public static string SumElementsInArray(this string[] param)
        {
            StringBuilder sum = new StringBuilder();

            foreach (string val in param)
            {
                sum.Append(val);
            }

            return sum.ToString();
        }

        /// <summary>
        /// считает сумму элементов массива
        /// </summary>
        /// <param name="param">массив типа char</param>
        /// <returns>сумма массива типа string</returns>
        public static string SumElementsInArray(this char[] param)
        {
            StringBuilder sum = new StringBuilder();

            foreach (char val in param)
            {
                sum.Append(val);
            }

            return sum.ToString();
        }
    }
}