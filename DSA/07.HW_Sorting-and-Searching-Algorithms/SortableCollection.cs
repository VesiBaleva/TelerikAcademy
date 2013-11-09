namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (T collectionItem in this.items)
            {
                if (collectionItem.CompareTo(item)==0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool BinarySearch(T item)
        {
            this.Sort(new Quicksorter<T>());

            int result = this.Binary_search(this.items, item, 0, this.items.Count-1);

            if (result != -1)
            {
                return true;
            }

            return false;
        }

        private int Binary_search(IList<T> collection, T item, int iMin, int iMax)
        {
            if (iMax < iMin)
            {
                return -1;
            }
            else
            {
                int iMid = (iMin + iMax) / 2;

                if (item.CompareTo(collection[iMid]) < 0)
                {
                    return Binary_search(collection, item, iMin, iMid - 1);
                }
                else if (item.CompareTo(collection[iMid]) > 0)
                {
                    return Binary_search(collection, item, iMid + 1, iMax);
                }
                else
                {
                    return iMid;
                }
            }
        }

        /// <summary>
        /// Shuffles the collection items performing
        /// Fisher-Yates algorithm. Algoritm complexity O(n)
        /// </summary>
        public void Shuffle()
        {
            Random randomGenerator = new Random();

            for (int i = this.items.Count - 1; i > 0; i--)
            {
                int randomIndex = randomGenerator.Next(0, i);

                T swapValue = this.items[i];
                this.items[i] = this.items[randomIndex];
                this.items[randomIndex] = swapValue;
            }      
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
