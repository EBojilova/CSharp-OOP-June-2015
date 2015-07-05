using System;

namespace CustomExceptions
{
    public class TankException : Exception//pravim si nash exception, koito naslediava sistemnia Exeption(base, this se izpolzva ako naslediavame ot tekustia klas)
    {
        public TankException(string msg)
            : base(msg)
        {
        }
    }
}
