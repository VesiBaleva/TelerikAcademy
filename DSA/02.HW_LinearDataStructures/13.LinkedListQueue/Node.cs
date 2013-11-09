using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.LinkedListQueue
{
    internal class Node<T> : IEnumerable<Node<T>>
    {
        public T Data { get; set; }

        public Node<T> NextNode { get; set; }

        public Node(T data)
        {
            this.Data = data;
            this.NextNode = null;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T> currentNode = this;

            do
            {
                Node<T> returnNode = currentNode;
                currentNode = currentNode.NextNode;
                yield return returnNode;
            }
            while (currentNode != null);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Node<T>>)this).GetEnumerator();
        }
    }
}
