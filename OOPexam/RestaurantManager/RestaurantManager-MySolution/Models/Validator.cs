namespace RestaurantManager.Models
{
    using System;

    internal static class Validator
    {
        private const string ParameterIsRequired = "The {0} is required.";

        private const string ParameterMustBePositive = "The {0} must be positive.";

        public static void StringNullEmptyValidator(string value, string parameter)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(string.Format(ParameterIsRequired, parameter));
            }
        }

        public static void PositiveValueCheck(decimal value, string parameter)
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(ParameterMustBePositive, parameter));
            }
        }

        public static void PositiveValueCheck(int value, string parameter)
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(ParameterMustBePositive, parameter));
            }
        }
    }
}