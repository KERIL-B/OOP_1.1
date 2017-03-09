using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Stack_Queue
{
    internal class MyNode<T>
    {
        public MyNode(T value)
        {
            this.data = value;
            this.next = null;
        }

        public T data { get; set; }
        public MyNode<T> next { get; set; }
    }

    interface IStack<T>
    {
        int Count { get;}

        bool IsEmpty{get;}

        void Push(T value);

        void Clear();

        T Pop();

        T Peek();
    }

    class Stack<T> : IStack<T>
    {
        public Stack()
        {
            head = null;
            current = null;
            count = 0;
        }

        MyNode<T> head;
        MyNode<T> current;

        int count;
        bool isEmpty;

        public int Count 
        { 
            get { return count; }
            
            private set
            {
                if (value >= 0)
                {
                    count = value;
                    isEmpty = count == 0;
                }
            }
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            private set{isEmpty=value;}
        }

        public void Push(T value)
        {
            if (head == null)
            {
                head = new MyNode<T>(value);
                current = head;
            }
            else
            {
                current.next = new MyNode<T>(value);
                current = current.next;
            }
            count++;
        }

        public void Clear()
        {
            head = null;
            current = null;
            count = 0;
        }

        public T Pop()
        {
            if (!isEmpty)
            {
                MyNode<T> tmp = head;
                MyNode<T> rtrn = current;

                for (int i = 0; i < count - 1; i++)
                {
                    tmp = tmp.next;
                }

                current = tmp;
                current.next = null;
                count--;

                return rtrn.data;
            }
            else throw new IndexOutOfRangeException("Stack is empty");
        }

        public T Peek()
        {
            if (isEmpty)
                throw new IndexOutOfRangeException("Stack is empty");
            else return current.data;

        }
    }

    class ArrayStack<T> : IStack<T>
    {
        T[] arrStack=new T[1000];

        int count;
        bool isEmpty;

        public int Count
        {
            get { return count; }

            private set
            {
                if (value >= 0)
                {
                    count = value;
                    isEmpty = count == 0;
                }
            }
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            private set { isEmpty = value; }
        }

        public void Push(T value)
        {
            arrStack[count] = value;
            count++;
        }

        public void Clear()
        {
            for (int i = 0; i < count; i++)
            {
                arrStack[i] = default(T);
            }    
            count = 0;
        }

        public T Pop() 
        {  
            T tmp=arrStack[count-2];
            arrStack[--count] = default(T);
            return tmp;

        }

        public T Peek()
        {
            return arrStack[count - 1];
        }
    }

    class LinckedStack<T> : IStack<T>
    {
        List<T> listStack=new List<T>();

        bool isEmpty;

        public int Count
        {
            get { return listStack.Count; }
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            private set { isEmpty = value; }
        }

        public void Push(T value)
        {
            listStack.Add(value);
        }

        public void Clear()
        {
            listStack.Clear();   
        }

        public T Pop()
        {
            T tmp=listStack[listStack.Count-2];
            listStack.RemoveAt(listStack.Count - 1);
            return tmp;

        }

        public T Peek()
        {
            return listStack[listStack.Count - 1];
        }
    }

}
