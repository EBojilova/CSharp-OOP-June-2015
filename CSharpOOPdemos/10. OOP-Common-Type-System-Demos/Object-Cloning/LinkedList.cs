namespace _3.ObjectCloning
{
    using System;
    using System.Text;

    internal class LinkedList<T> : ICloneable
    {
        public LinkedList(T value, LinkedList<T> nextLinkedList = null)
        {
            this.Value = value;
            this.NextLinkedList = nextLinkedList;
        }

        public T Value { get; set; }

        public LinkedList<T> NextLinkedList { get; private set; }

        object ICloneable.Clone()
        {
            // Implicit interface implementation
            return this.Clone();
        }

        public LinkedList<T> ShallowCopy()
        {
            return this;
        }

        public LinkedList<T> MemberwiseCopy()
        {
            return (LinkedList<T>)this.MemberwiseClone();
        }

        public LinkedList<T> Clone()
        {
            // Deep cloning (public method)
            // Copy the first element
            var original = this;
            var result = new LinkedList<T>(this.Value);
            var copy = result; // copy and result imat obst adres i ste se promeniat zaedno
            original = original.NextLinkedList;

            // Copy the rest of the elements
            while (original != null)
            {
                copy.NextLinkedList = new LinkedList<T>(original.Value);
                original = original.NextLinkedList;
                copy = copy.NextLinkedList;
            }

            return result;
        }

        public override string ToString()
        {
            var currentNode = this;
            var sb = new StringBuilder("(");
            while (currentNode != null)
            {
                sb.Append(currentNode.Value);
                currentNode = currentNode.NextLinkedList;
                if (currentNode != null)
                {
                    sb.Append(", ");
                }
            }

            sb.Append(")");

            return sb.ToString();
        }
    }
}