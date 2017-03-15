using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue
{
    interface IQueue<T>
    {
        int Count { get; }
        bool IsEmpty { get; }

        void Enqueue(T value);
        void Clear();
        T Dequeue();
        T Peek();
    }

    class ArrayQueue<T> : IQueue<T>
    {
        T[] arr = new T[1000];
        public ArrayQueue()
        {
            count = 0;
        }

        int count;
        bool isEmpty;

        public int Count
        {
            get { return count; }
            private set
            {
                count = value;
                isEmpty = count == 0;
            }
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            private set { isEmpty = value; }
        }

        public void Enqueue(T value)
        {
            for (int i = count - 1; i > 0; )
                arr[i] = arr[--i];
            arr[0] = value;
        }

        public void Clear()
        {
            for (int i = 0; i < count; i++)
            {
                arr[i] = default(T);
            }
            count = 0;
        }

        public T Dequeue()
        {
            T tmp = arr[count - 1];
            arr[--count] = default(T);
            return tmp;
        }

        public T Peek()
        {
            return arr[count - 1];
        }
    }

    class LinkedQueue<T> : IQueue<T>
    {
        List<T> list = new List<T>();

        public LinkedQueue()
        {
            count = 0;
        }

        int count;
        bool isEmpty;

        public int Count
        {
            get { return count; }
            private set
            {
                count = value;
                isEmpty = count == 0;
            }
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            private set { isEmpty = value; }
        }

        public void Enqueue(T value)
        {
            list.Add(value);
            count++;
        }

        public void Clear()
        {
            while (count > 0)
            {
                list[--count] = default(T);
            }
        }

        public T Dequeue()
        {
            if (IsEmpty)
            { throw new OutOfRangeException("Queue is empty"); }
            else
            {
                T tmp = list[0];
                for (int i = 0; i < count - 1; )
                {
                    list[i] = list[++i];
                }
                count--;
                return tmp;
            }
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new OutOfRangeException("Queue is empty");
            else
                return list[0];
        }
    }
}
