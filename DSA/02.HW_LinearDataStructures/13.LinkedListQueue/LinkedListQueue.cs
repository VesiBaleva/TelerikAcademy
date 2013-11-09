using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.LinkedListQueue
{
    public class LinkedListQueue<T> : IEnumerable<T>
    {
        private int size;

        private Node<T> head;

        private Node<T> tail;

        public int Count
        {
            get
            {
                return this.size;
            }
        }

        public void Clear()
        {
            this.size = 0;
            this.head = null;
            this.tail = null;
        }

        public bool Contains(T item)
        {
            foreach (Node<T> node in this.head)
            {
                if (EqualityComparer<T>.Default.Equals(node.Data, item))
                {
                    return true;
                }
            }

            return false;
        }

        public T Dequeue()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Queue empty.");
            }

            T currentItem = this.head.Data;

            if (object.ReferenceEquals(this.head, this.tail))
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = this.head.NextNode;
            }

            this.size--;

            return currentItem;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (this.tail != null)
            {
                this.tail.NextNode = newNode;
            }
            else
            {
                this.head = newNode;
            }

            this.tail = newNode;

            this.size++;
        }

        public T Peek()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Queue empty.");
            }

            T currentItem = this.head.Data;
            return currentItem;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.size];

            int index = 0;

            foreach (Node<T> node in this.head)
            {
                array[index] = node.Data;
                index++;
            }

            return array;
        }

        public override string ToString()
        {
            if (this.size == 0)
            {
                return string.Empty;
            }

            return string.Join(", ", this.ToArray());
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (Node<T> node in this.head)
            {
                yield return node.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
