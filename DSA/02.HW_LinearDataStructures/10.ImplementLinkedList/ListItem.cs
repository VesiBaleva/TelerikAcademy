using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ImplementLinkedList
{
    public class ListItem<T>
    {
        private T value;

        private ListItem<T> nextItem;

        public ListItem(T value)
        {
            this.Value = value;
            this.NextItem = null;
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public ListItem<T> NextItem
        {
            get
            {
                if (this.nextItem == null)
                {
                    return null;
                }

                return this.nextItem; 
            }

            set
            {
                this.nextItem = value;
            }
        }
    }
}
