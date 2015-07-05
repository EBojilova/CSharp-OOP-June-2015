namespace WinterIsComing.Models.Units
{
    using System;

    using WinterIsComing.Core.Exceptions;

    internal static class Validator
    {
        private const int MaxMatrixSize = 5;

        public static void PositonCheck(int coordiante)
        {
            if (coordiante < 0 || coordiante >= MaxMatrixSize)
            {
                throw new InvalidPositionException(
                    string.Format("Coordinate has to be in range [0,{0}]", MaxMatrixSize));
            }
        }

        public static void StringCeck(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentNullException("word", "String cannot be null, empty or whitespace.");
            }
        }
    }
}