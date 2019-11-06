using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LimitedList 
{
    public class LimitedList<T> : IEnumerable<T>   //this is a generic class
    {
        private readonly int capacity;  //can't be changed after creation
        private readonly List<T> list;

        public LimitedList(int capacity)
        {
            this.capacity = Math.Max(0, capacity);
            list = new List<T>(capacity); //we do not know what we will save in the list yet
        }

        public int Count => list.Count;
        public bool IsFull => capacity <= Count;

        public bool Add(T item)
        {
            if (IsFull) return false;
            list.Add(item);
            return true;
        }

        public bool Remove(T item) => list.Remove(item);

        public IEnumerator<T> GetEnumerator()
        {
            //return list.GetEnumerator();
            foreach (var item in list)  //var is of type T
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();    //IEnumerator<T> ärver av IEnumerator
                                                            //så vi måste implementera IEnumerator.GetEnumerator också
                                                            //Implicit metoddeklaration
       


    }
}
