using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ImplementLinkedList
{
    public class CustomLinkedList<T>
    {
        private ListItem<T> firstElement;

        private int itemCount = 0;

        public int Count
        {
            get
            {
                return this.itemCount;
            }

        }

        public CustomLinkedList()
        {
            this.firstElement = null;
        }

        public ListItem<T> FirstElement
        {
            get
            {
                return this.firstElement;
            }
            set
            {
                this.firstElement = value;
            }
        }

        public void AddFirst(T value)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new ListItem<T>(value);
            }
            else
            {
                ListItem<T> newListItem = new ListItem<T>(value);
                newListItem.NextItem = this.FirstElement;
                this.FirstElement = newListItem;
            }

            this.itemCount++;
        }

        public void AddLast(T value)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new ListItem<T>(value);
            }
            else
            {
                ListItem<T> newListItem = this.firstElement;
                while (newListItem.NextItem != null)
                {
                    newListItem = newListItem.NextItem;
                }

                newListItem.NextItem = new ListItem<T>(value);
            }

            this.itemCount++;
            

        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.itemCount)
                {
                    throw new ArgumentOutOfRangeException(
                        "index", "Index was out of range. Must be non-negative and less than the size of the collection.");
                }

                ListItem<T> currentItem = this.FirstElement;

                for (int i = 0; i < index; i++)
                {
                    currentItem = currentItem.NextItem;
                }

                return currentItem.Value;
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException(
                        "index",
                        "Index was out of range. Must be non-negative and less than the size of the collection.");
                }

                ListItem<T> currentItem = this.FirstElement;

                for (int i = 0; i < index; i++)
                {
                    currentItem = currentItem.NextItem;
                }

                currentItem.Value = value;
            }
        }
             
        public void Clear()
        {
            this.itemCount = 0;
            this.FirstElement = null;
        }

        public int IndexOf(T item)
        {
            int index = 0;
            ListItem<T> currentItem = this.FirstElement;

            while (currentItem != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentItem.Value, item))
                {
                    return index;
                }

                currentItem = currentItem.NextItem;
                index++;
            }

            return -1;
        }

        public bool Contains(T item)
        {
            int index = this.IndexOf(item);
            bool found = (index != -1);
            return found;
        }

        private void RemoveBeginning()
        {
            this.FirstElement = this.FirstElement.NextItem;
            this.itemCount--;
        }

        private void RemoveAfter(ListItem<T> item)
        {
            item.NextItem = item.NextItem.NextItem;
            this.itemCount--;
        }

        public bool Remove(T item)
        {
            if (this.itemCount == 0)
            {
                return false;
            }

            if (this.itemCount == 1)
            {
                if (EqualityComparer<T>.Default.Equals(this.FirstElement.Value, item))
                {
                    this.RemoveBeginning();
                    return true;
                }

                return false;
            }

            ListItem<T> currentItem = this.FirstElement;

            while (currentItem.NextItem != null)
            {
                if (EqualityComparer<T>.Default.Equals(currentItem.NextItem.Value, item))
                {
                    break;
                }

                currentItem = currentItem.NextItem;
            }

            if (currentItem.NextItem != null)
            {
                this.RemoveAfter(currentItem);
                return true;
            }
            else
            {
                
                return false;
            }
        }
       
    }
}
