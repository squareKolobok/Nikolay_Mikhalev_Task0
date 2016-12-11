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
                if (!char.IsNumber(param[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}