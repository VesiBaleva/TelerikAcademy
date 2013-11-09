namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections;
    using System.Text;
    using System.Threading.Tasks;

       
    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null!");
            }

            IList<T> sortedCollection = this.QuickSort(collection);

            collection.Clear();

            foreach (T item in sortedCollection)
            {
                collection.Add(item);
            }
        }

        private IList<T> QuickSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int pivot = collection.Count / 2;
            T pivotValue = collection[pivot];
            collection.RemoveAt(pivot);
            IList<T> lesser = new List<T>();
            IList<T> greater = new List<T>();
            foreach (T element in collection)
            {
                if (element.CompareTo(pivotValue) < 0)
                {
                    lesser.Add(element);
                }
                else
                {
                    greater.Add(element);
                }
            }

            List<T> result = new List<T>();
            result.AddRange(QuickSort(lesser));
            result.Add(pivotValue);
            result.AddRange(QuickSort(greater));
            return result;
        }
    }
}
