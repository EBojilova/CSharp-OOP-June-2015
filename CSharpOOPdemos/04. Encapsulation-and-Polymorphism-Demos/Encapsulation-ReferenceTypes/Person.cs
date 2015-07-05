namespace _1._1.Encapsulation_ReferenceTypes
{
    using System;
    using System.Collections.Generic;

    public class Person
    {
        private const int MinPersonAge = 0;

        private const int MaxPersonAge = 120;

        private readonly List<string> aliases = new List<string>();//vapreki che e dadeno kato readonly to se otnasia samo za adresa(toi ste e readonly) i tova moje da dovede do greshka, tai kato lista e referenten tip i moje da se promenia(niama da e readonly)

        private int age;

        private string name;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A person's name cannot be null, empty or whitespace.", "value");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < MinPersonAge || MaxPersonAge < value)
                {
                    throw new ArgumentOutOfRangeException(
                        "value", 
                        string.Format("A person's age must be in the range [{0} ... {1}].", MinPersonAge, MaxPersonAge));
                }

                this.age = value;
            }
        }

        public List<string> Aliases
        {
            get
            {
                return this.aliases; // vapreki che e samo get moje da se promenia, tai kato e referenten tip, izhoda e da se varne kopie na lista ili metoda OTDOLU
            }
        }

        public IEnumerable<string> AliasesEnumerable // po tozi nachina niama dostap po inexi ,niama add i tn.(za razlika ot List
        {
            get
            {
                return this.aliases;
            }
        }
        public void AddAlias(string alias)
        {
            this.aliases.Add(alias);
        }
    }
}