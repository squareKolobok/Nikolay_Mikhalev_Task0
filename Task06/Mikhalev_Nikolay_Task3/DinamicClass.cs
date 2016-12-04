namespace Mikhalev_Nikolay_Task3
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class DinamicArray<T> : IEnumerable<T>, IEnumerator<T>
    {
        private T[] data;
        /// <summary>
        /// длина массива
        /// </summary>
        public int Length { get; private set; }
        /// <summary>
        /// колличество элементов в массиве
        /// </summary>
        public int Capacity { get; private set; }
        private int position = 0;

        public T Current
        {
            get
            {
                return data[position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return data[position];
            }
        }

        /// <summary>
        /// Задание динамического массива с заданной длиной
        /// </summary>
        /// <param name="length">длина массива</param>
        public DinamicArray(int length)
        {
            length = length > 0 ? length : 8;
            data = new T[length];
            Length = length;
            Capacity = 0;
        }

        /// <summary>
        /// Задание динамического массива по умолчанию
        /// </summary>
        public DinamicArray()
            : this(8)
        {
        }

        /// <summary>
        /// Задание динамического массива из коллекции, реализующей интерфейс IEnumerable<T> 
        /// </summary>
        /// <param name="enumer">коллекция, реализующая интерфейс IEnumerable</param>
        public DinamicArray(IEnumerable<T> enumer)
        {
            int l = enumer.Count();
            data = new T[l];
            Capacity = 0;
            Length = l;
            AddRange(enumer);
        }

        /// <summary>
        /// добавление элемента в массив, в случае переполнения массива его длина увеличивается в 2 раза
        /// </summary>
        /// <param name="elem">входящий элемент</param>
        public void Add(T elem)
        {
            if (Capacity < Length)
            {
                data[Capacity] = elem;
                Capacity++;
            }
            else
            {
                T[] newData = new T[Length * 2];
                Length *= 2;
                data.CopyTo(newData, 0);
                data = newData;
                Add(elem);
            }
        }

        /// <summary>
        /// добавление коллекции, реализующей интерфейс IEnumerable<T> в массив
        /// </summary>
        /// <param name="enumer">входящая коллекция</param>
        public void AddRange(IEnumerable<T> enumer)
        {
            if (Capacity + enumer.Count() <= Length)
            {
                foreach (T elem in enumer)
                {
                    Add(elem);
                }
            }
            else
            {
                T[] newData = new T[Length + enumer.Count()];
                Length += enumer.Count();
                data.CopyTo(newData, 0);
                data = newData;
                AddRange(enumer);
            }
        }

        /// <summary>
        /// удаляет указанный элемент
        /// </summary>
        /// <param name="elem">элемент который нужно удалить из массива</param>
        /// <returns>возвращает false, если указанного элемента не было в массиве, иначе возвращает true</returns>
        public bool Remove(T elem)
        {
            int pos = 0;

            do
            {
                if (data[pos].Equals(elem))
                {
                    break;
                }

                pos++;
            }
            while (pos < Capacity);

            if (pos < Capacity)
            {
                Array.Copy(data, pos + 1, data, pos, Capacity - pos - 1);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// добавляет элемент в произвольную позицию
        /// </summary>
        /// <param name="elem">добавляемый элемент</param>
        /// <param name="index">позиция в которую нужно добавить элемент</param>
        /// <returns>возвращает true когда index меньше Capasity</returns>
        public bool Insert(T elem, int index)
        {
            if (index <= Capacity && index > -1)
            {
                Array.Copy(data, index, data, index + 1, Capacity - index - 1);
                data[index] = elem;
                return true;
            }
            else if (index < Length && index > -1)
            {
                return false;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Выход за границы массива");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)data).GetEnumerator();
        }

        public bool MoveNext()
        {
            if (position + 1 < Capacity)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        public T this[int i]
        {
            get
            {
                if (i < Capacity && i > -1)
                {
                    return data[i];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Выход за границы массива");
                }
            }
        }

        //что с этим делать не понял
        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~DinamicClass() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}