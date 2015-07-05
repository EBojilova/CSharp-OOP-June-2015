using System;

namespace Generic_Classes
{
    public class GenericList<T> // where T: IComparable<T>- ako iskame T da moje da se srvniava, triabva zadaljitelno da implementira Interface IComparable
    {
        private const int DefaultCapacity = 4096;

        private readonly T[] elements;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.Count = 0;
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException(string.Format("Invalid index: {0}.", index));
                }

                var result = this.elements[index];

                return result;
            }
        }

        public void Add(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                throw new IndexOutOfRangeException(
                    string.Format("The list capacity of {0} was exceeded.", this.elements.Length));
            }

            this.elements[this.Count] = element;
            this.Count++;
        }
    }
}