namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null!");
            }

            IList<T> sortedCollection = this.MergeSort(collection);

            collection.Clear();

            foreach (T item in sortedCollection)
            {
                collection.Add(item);
            }
        }


        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;

            }

            int middle = collection.Count / 2;

            IList<T> left = new List<T>(); 

            for (int index = 0; index < middle; index++)
            {
                left.Add(collection[index]);
            }

            IList<T> right = new List<T>(); 
            for (int index = middle; index < collection.Count; index++)
            {
                right.Add(collection[index]);
            }

            left=MergeSort(left);
            right=MergeSort(right);
            return this.Merge(left, right);
        }

        private IList<T> Merge(IList<T> left, IList<T> right)
        {
            IList<T> result = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0].CompareTo(right[0]) <= 0)
                    {
                        result.Add(left[0]);
                        left.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.RemoveAt(0);
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else if (right.Count > 0)
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }                
            }

            return result;
        }
    }
}
