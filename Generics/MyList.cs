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


        // Operator overloading
        // Problem: no generic constraint taht allows operator overloading
        //      https://stackoverflow.com/questions/8122611/c-sharp-adding-two-generic-values
        // Solution: "dynamic" keyword
        //      what about type-safety ?? (doesn't apply any compile time safety which is what generics are meant)
        //      -> only way for compile time safety is generic constraints!
        // 
        //
        public static MyList<T> operator +(MyList<T> myList1, MyList<T> myList2)
        {
            MyList<T> result = new();

            if (myList1.count != myList2.count)
            {
                throw new InvalidOperationException("Lists have to be of the same size!");
            }
            else
            {
                for (int i = 0; i < myList1.count; i++)
                {
                    result.Add((dynamic)myList1[i] + (dynamic)myList2[i]);      //dynamic
                }
            }

            return result;
        }


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
