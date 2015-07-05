namespace ImplementingIEnumerable
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    internal class LinkedListEnumerator<T> : IEnumerator<T> // tova e javarskia nachin pri koito se implementirat vsichki metodi, tai kato niama yield return
    {
        private readonly LinkedList<T> initialLinkedList;

        private LinkedList<T> currentLinkedList;

        private bool isStarted;

        public LinkedListEnumerator(LinkedList<T> firstLinkedList)
        {
            this.currentLinkedList = firstLinkedList;
            this.initialLinkedList = firstLinkedList;
        }

        public T Current
        {
            get
            {
                return this.currentLinkedList.Value;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.currentLinkedList.Value;
            }
        }

        public bool MoveNext()
        {
            if (!this.isStarted)
            {
                this.isStarted = true;
                return true;
            }

            if (this.currentLinkedList.NextLinkedList != null)
            {
                this.currentLinkedList = this.currentLinkedList.NextLinkedList;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.isStarted = false;
            this.currentLinkedList = this.initialLinkedList;
        }

        public void Dispose()
        {
        }
    }
}