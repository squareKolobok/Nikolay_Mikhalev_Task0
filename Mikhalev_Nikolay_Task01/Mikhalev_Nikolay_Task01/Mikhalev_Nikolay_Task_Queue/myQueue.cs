namespace Mikhalev_Nikolay_Task_Queue
{
    public class myQueue<T>
    {
        private T data = default(T);//хранимое значение //todo по умолчанию всегда будет присваиваться значение по умолчанию, поэтому достаточно просто "...data;"
        private static int LengthStack = 0;//длина очереди//todo пока не проходили, но лучше сделать это поле не статическим.
        private static myQueue<T> endLink = null;//последний элемент очереди //todo пока не проходили, но лучше сделать это поле не статическим.
        private myQueue<T> prev = null;//ссылка предыдущий элимент//todo судя по сигнатуре, ссылка-то на какой-то другой стек, а не на элемент стека.  

        //конструкторы стека
        public myQueue()
        {
        }
        private myQueue(T newData)
        {
            data = newData;
        }
        public void Enqueue(T param)
        {
            if (Empty())
            {
                prev = new myQueue<T>(param);
                endLink = prev;
            }
            else
            {
                endLink.prev = new myQueue<T>(param);
                endLink = endLink.prev;
            }
            LengthStack++;
        }

        public T Dequeue()
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

        public T Front()
        {
            if (!Empty())
            {
                return prev.data;
            }
            return default(T);
        }

        public bool Empty()//todo лучше переименовать в IsEmpty, поскольку метод по сути своей флаг
        {
            return LengthStack == 0 ? true : false;//todo return LengthStack == 0 делает тоже самое, что и return LengthStack == 0 ? true : false
        }
    }
}