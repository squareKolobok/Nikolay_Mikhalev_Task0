namespace Mikhalev_Nikolay_Task2
{
    public static class StringIsPositivNumber
    {
        /// <summary>
        /// проверяет является ли строка положительным числом
        /// </summary>
        /// <param name="param"></param>
        /// <returns>возращает true если строка является положительным числом, иначе false</returns>
        public static bool IsPositivNumber(this string param)
        {
            for (int i = 0; i < param.Length; i++)
            {
                if (!char.IsNumber(param[i]))//todo всё же этот код больше похож на хак, чем на решение задачи :) лучше бы вызывал исключение, если бы передавалось не число, конвертил значение и сравнивал с нулем (в учебных целях :))
                {
                    return false;
                }
            }

            return true;
        }
    }
}