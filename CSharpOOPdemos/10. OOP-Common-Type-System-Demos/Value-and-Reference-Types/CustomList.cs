namespace Value_And_Reference_Types
{
    using System.Collections.Generic;
    using System.Reflection;

    public class CustomList
    {
        private List<int> nums;

        // Po tozi nachin se ogranichava dostapa do lista, do osnovnite komandi na object, t.e lista moje samo da se foreach
        public IEnumerable<int> Numbers
        {
            get
            {
                return this.nums;
            }
        }

        // pravim si Add, koito nie si implementirame i togava samo dobaviame
        public void Add(int newNum)
        {
            if (newNum < 5)
            {
                throw new CustomAttributeFormatException("Added number should be larger than 4.");
            }
            this.nums.Add(newNum);
        }
    }
}