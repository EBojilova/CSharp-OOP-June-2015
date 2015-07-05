namespace AttributeValidation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using AttributeValidation.Attributes;
    using AttributeValidation.Models;

    public class AttributeValidaiton
    {
        static void Main()
        {
            var warriors = new List<Warrior>()
            {
                new Warrior()
                {
                    Name = "Gosho",
                    //Weapon = new Weapon()
                },
                new Warrior()
                {
                    //Name = "Pesho",
                    Weapon = new Weapon()
                },
                new Warrior()
                {
                    //Name = "Gencho",
                    //Weapon = new Weapon()
                }
            };

            try
            {
                ValidateRequiredProperties(warriors);
            }
            catch (AggregateException ex)
            {
                Console.Error.WriteLine(ex.Flatten());//Flatten dava sakraten vid na exeptiona
            }
        }

        private static void ValidateRequiredProperties<T>(IEnumerable<T> entities)
        {
            var requiredProperties = typeof(T)//vzimame dadena instancia klas, primerno Worrior
                .GetProperties()//vzemame mu vsichki propertita
                .Where(pr => pr.GetCustomAttributes(false)//izbiram propertitta s custom atributi, bez klasovete na roditelite im
                    .Any(a => a is RequiredAttribute));//i proveriavam s Any dali ima atributa e s RequiredAttribute

            var exceptions = new List<Exception>();
            foreach (var warrior in entities)
            {
                foreach (var prop in requiredProperties)//vsichki propertita s Required
                {
                    if (prop.GetValue(warrior) == null)//tova e getara na propertito prop ot klasa warrior
                    {
                        var ex = new ArgumentNullException(prop.Name);

                        exceptions.Add(ex);
                    }
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
