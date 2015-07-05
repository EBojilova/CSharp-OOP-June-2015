namespace WinterIsComing.Core.Exceptions
{
    public class NotEnoughEnergyException : GameException
    {
        public NotEnoughEnergyException(string msg)
            : base(msg)
        {
        }
    }
}