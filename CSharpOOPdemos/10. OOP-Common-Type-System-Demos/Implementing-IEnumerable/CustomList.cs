namespace ImplementingIEnumerable
{
    using System.Collections;
    using System.Collections.Generic;

    internal class CustomList<T> : IEnumerable<T>
    {
        public CustomList()
        {
            this.Elements = new T[16];
            this.Index = 0;
        }

        public T[] Elements { get; set; }

        public int Index { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < this.Index; i++)
            {
                yield return this.Elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(T element)
        {
            this.Elements[this.Index] = element;
            this.Index++;
        }
    }
}