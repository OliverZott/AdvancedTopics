using System;
using System.Collections;
using System.Collections.Generic;

namespace Generics
{

    /// Example class which implements a List by using Arrays and re-initialize
    /// array if full by double the size.
    /// 
    /// Questions:
    ///     - Why can IEnumerable be used without <T>
    ///     - Whats is the exact difference between return and / yield (why return anyways?)
    ///     - Whats the second implemented method for (the one without access modifier)
    class MyList<T> : IEnumerable<T>
    {

        private T[] items;
        private int count;
        private int capacity;

        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
            }
        }
        public int Capacity
        {
            get
            {
                return this.capacity;

            }
            private set
            {
                this.capacity = value;
            }
        }

        // Define the indexer to allow client code to use [] notation.
        // 'this' -keyword refers to the current instance of the class!
        public T this[int i]
        {
            get { return items[i]; }
            set { items[i] = value; }
        }


        public MyList()
        {
            this.items = new T[2];
            this.capacity = 2;
            this.count = 0;
        }


        public void Add(T item)
        {
            if (this.count == this.capacity)
            {
                T[] clone = (T[])items.Clone();

                this.capacity *= 2;
                this.items = new T[this.capacity];

                Array.Copy(clone, this.items, clone.Length);
            }
            this.items[this.count] = item;
            this.count++;
        }


        //public IEnumerator<T> GetEnumerator()
        //{
        //    foreach (var item in items)
        //    {
        //        yield return item;
        //    }
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return this.GetEnumerator();
        //}


        #region strongly typed version (https://stackoverflow.com/questions/11296810/how-do-i-implement-ienumerablet)
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        // whats this for ??
        IEnumerator IEnumerable.GetEnumerator()
        {
            // use strongly typed IEnumerable<T> implementation
            return this.GetEnumerator();
        }

        #endregion


        #region Enumerator implementation (non-Generic)

        //public IEnumerator GetEnumerator()
        //{
        //    foreach (var item in items)
        //    {
        //        yield return item;
        //    }
        //}

        #endregion

    }
}
