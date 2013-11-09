using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.StackAsAuto_resizableArray
{
    public class StackAsAutoResizableArray<T>
    {
        private T[] array;

        private int size;

        private static T[] emptyArray;

        private const int DefaultCapacity = 4;

        public int Count
        {
            get
            {
                return this.size;
            }
        }

        static StackAsAutoResizableArray()
        {
            StackAsAutoResizableArray<T>.emptyArray = new T[0];
        }

        public StackAsAutoResizableArray(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("capacity", "Capacity must be non-negative!");
            }

            this.array = new T[capacity];
            this.size = 0;
        }

        public void Clear()
        {
            Array.Clear(this.array, 0, this.size);
            this.size = 0;
        }

        public bool Contains(T item)
        {
            if (this.size == 0)
            {
                return false;
            }

            for (int i = 0; i < this.size; i++)
            {
                if (EqualityComparer<T>.Default.Equals(this.array[i], item))
                {
                    return true;
                }
            }

            return false;
        }

        public T Peek()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException("stack empty!");
            }

            return this.array[this.size - 1];
        }

        public T Pop()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException("stack empty!");
            }

            T top = this.array[this.size - 1];
            this.array[this.size - 1] = default(T);
            this.size--;

            return top;
        }

        public void Push(T item)
        {
            if (this.size == this.array.Length)
            {
                int capacity;
                if (this.array.Length == 0)
                {
                    capacity = DefaultCapacity;
                }
                else
                {
                    capacity = 2 * this.array.Length;
                }

                T[] extended = new T[capacity];
                Array.Copy(this.array, 0, extended, 0, this.size);
                this.array = extended;
            }

            this.array[this.size] = item;
            this.size++;
        }

        public T[] ToArray()
        {
            T[] result = new T[this.size];
            for (int i = 0; i < this.size; i++)
            {
                result[i] = this.array[this.size - i - 1];

            }
            return result;
        }

        public override string ToString()
        {
            if (this.size == 0)
            {
                return string.Empty;
            }

            return string.Join(", ", this.ToArray());
        }


    }
}
