namespace Mikhalev_Nikolay_Task_Stak
{
    public class myStack<T>
    {
        private T data = default(T);//хранимое значение
        private static int LengthStack = 0;//длина стека
        private myStack<T> prev = null;//ссылка предыдущий элимент

        //конструктор стека
        public myStack()
        {
        }
        private myStack(T newData, myStack<T> linkStak)
        {
            data = newData;
            prev = linkStak;
        }
        public void Push(T param)
        {
            LengthStack++;
            prev = new myStack<T>(param, prev);
        }

        public T Pop()
        {
            if (!Empty())
            {
                LengthStack--;
                T d = prev.data;
                prev = prev.prev;
                return d;
            }
            return default(T);
        }

        public T Get()
        {
            if (!Empty())
            {
                return prev.data;
            }
            return default(T);
        }

        public bool Empty()
        {
            return LengthStack == 0 ? true : false;
        }
    }
}