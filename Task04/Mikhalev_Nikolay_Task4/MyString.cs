namespace Mikhalev_Nikolay_Task4
{
    using System;

    internal class MyString
    {
        private char[] arr;
        public int Length { get; private set; }

        public MyString()
        {
            Length = 0;
            arr = new char[Length];
        }

        public MyString(char[] value)
        {
            Length = value.Length;
            arr = new char[Length];
            Array.Copy(value, arr, Length);
        }

        public char this[int i]
        {
            get { return arr[i]; }
        }

        public static MyString operator +(MyString str1, MyString str2)
        {
            int l = str1.Length + str2.Length;
            char[] arr = new char[l];
            Array.ConstrainedCopy(str1.arr, 0, arr, 0, str1.Length);
            Array.ConstrainedCopy(str2.arr, 0, arr, str1.Length, str2.Length);
            str1.arr = arr;
            str1.Length = l;
            return str1;
        }

        public override bool Equals(object obj)
        {
            if (obj is MyString)
            {
                bool res = true;
                MyString value = (MyString)obj;

                if (value.Length == Length)
                    for (int i = 0; i < Length; i++)
                        res = res && (arr[i] == value[i]);
                else
                    res = false;

                return res;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int h = Length;
            foreach (char c in arr)
            {
                h = h ^ c;
            }
            return h;
        }

        public int IndexOf(char value, int startIndex)
        {
            int res = -1;

            for (int i = startIndex; i < Length; i++)
                if (value == arr[i])
                {
                    return i;
                }

            return res;
        }

        public int IndexOf(char value)
        {
            return IndexOf(value, 0);
        }

        public override string ToString()
        {
            return new string(arr);
        }
    }
}