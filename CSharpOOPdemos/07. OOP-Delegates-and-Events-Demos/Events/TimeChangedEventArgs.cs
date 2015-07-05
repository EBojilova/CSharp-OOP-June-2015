namespace _6.Events
{
    using System;

    public class TimeChangedEventArgs : EventArgs // klas, koito se podava kato argument na darjacha delegat na eventa
    {
        public TimeChangedEventArgs(int ticksLeft)
        {
            this.TicksLeft = ticksLeft;
        }

        public int TicksLeft { get; private set; }
    }
}