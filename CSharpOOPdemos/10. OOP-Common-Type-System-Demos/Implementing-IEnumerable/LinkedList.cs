namespace ImplementingIEnumerable
{
    using System.Collections;
    using System.Collections.Generic;

    internal class LinkedList<T> : IEnumerable<T>
    {
        public LinkedList(T value, LinkedList<T> nextLinkedList = null)
        {
            this.Value = value;
            this.NextLinkedList = nextLinkedList;
        }

        public T Value { get; set; }

        public LinkedList<T> NextLinkedList { get; private set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // tova moje i da ne se implementira- ot po-starata versia e, na koiato e niamalo generic
            // Call the generic version of the method
            return this.GetEnumerator();
        }

        // ot Main metoda vlizame v tozi method
        public IEnumerator<T> GetEnumerator()
        {
            var currentLinkedList = this;
            while (currentLinkedList != null)
            {
                yield return currentLinkedList.Value;
                currentLinkedList = currentLinkedList.NextLinkedList;
            }

            //call the custom version of the method- tova e javarskia nachin, pri koito niama yield(samo c#) i vseki pat triabva da se implementirat s dalga logika metodi- vij MoveNex ot LinkedListEnumerator
            //return new LinkedListEnumerator<T>(this);
        }
    }
}