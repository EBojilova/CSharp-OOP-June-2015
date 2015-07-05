using System;

namespace RestaurantManager.Models
{
    public static class Validation
    {
        private const int MaxDrinkCalories = 100;
        private const int MaxDrinkTimeToPrepare = 20;

        public static void ForRequiredString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Parameter is required.");
            }
        }

        public static void ForPositiveNumber(decimal number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Parameter must be positive.");
            }
        }

        public static void ForDrinkCalories(decimal calories)
        {
            if (calories > MaxDrinkCalories)
            {
                throw new ArgumentException("Calories in a drink cannot be more than " + MaxDrinkCalories + ".");
            }
        }

        public static void ForDrinkTimeToPrepare(decimal time)
        {
            if (time > MaxDrinkTimeToPrepare)
            {
                throw new ArgumentException("The time to prepare a drink cannot be more than " + MaxDrinkTimeToPrepare + ".");
            }
        }
    }
}
