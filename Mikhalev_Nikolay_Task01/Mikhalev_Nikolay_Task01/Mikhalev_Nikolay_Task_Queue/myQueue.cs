namespace Mikhalev_Nikolay_Task_Queue
{
    public class myQueue<T>
    {
        private T data = default(T);//хранимое значение
        private static int LengthStack = 0;//длина очереди
        private static myQueue<T> endLink = null;//последний элемент очереди 
        private myQueue<T> prev = null;//ссылка предыдущий элимент

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

        public bool Empty()
        {
            return LengthStack == 0 ? true : false;
        }
    }
}