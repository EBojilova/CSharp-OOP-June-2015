namespace CustomStackExample
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomStack<T>
        where T : IComparable<T>
    {
        // : IEnumerable<T> where T : IComparable<T> //Kateto go predloji za da moje da se izpalniava for-vij otdolu dvata zakomentirani methoda
        private const int DefaultCapacity = 16;

        private T[] elements;

        public CustomStack(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public bool IsEmpty
        {
            get
            {
                return this.Count == 0;
            }
        }

        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Resize();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var topElement = this.elements[this.Count - 1];
            this.elements[this.Count - 1] = default(T);
            this.Count--;

            return topElement;
        }

        public void Clear()
        {
            for (var i = 0; i < this.Count; i++)
            {
                this.elements[i] = default(T);
            }

            this.Count = 0;
        }

        public bool Contains(T element)
        {
            for (var i = 0; i < this.Count; i++)
            {
                var currentElement = this.elements[i];
                if (currentElement.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public T Min()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var min = this.elements[0];
            for (var i = 1; i < this.Count; i++)
            {
                var currentElement = this.elements[i];
                if (currentElement.CompareTo(min) < 0)
                {
                    min = currentElement;
                }
            }

            return min;
        }

        public override string ToString()
        {
            var resultElements = this.elements.Take(this.Count);

            // ne ni triabva cialata daljina, a samo chasta koiato e zapalnena
            return string.Join(", ", resultElements);
        }

        private void Resize()
        {
            // tozi method niama nujda da se vijda ot usera
            var newElements = new T[this.elements.Length * 2];
            for (var i = 0; i < this.elements.Length; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }

        //IEnumerator<T> IEnumerable<T>.GetEnumerator()
        //{
        //    for (int i = 0; i < this.currentIndex; i++)
        //    {
        //        yield return elements[i];
        //    }
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    for (int i = 0; i < this.currentIndex; i++)
        //    {
        //        yield return elements[i];
        //    }
        //}
    }
}