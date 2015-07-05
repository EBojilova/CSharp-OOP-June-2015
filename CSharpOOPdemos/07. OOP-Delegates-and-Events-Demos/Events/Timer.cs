namespace _6.Events
{
    using System.Threading;

    public class Timer
    {
        public Timer(int tickCount, int interval)
        {
            this.TickCount = tickCount;
            this.Interval = interval;
        }

        public int TickCount { get; private set; }

        public int Interval { get; private set; }

        public event TimeChangedEventHandler TimeChangedEvent;

        public void Run()
        {
            var tick = this.TickCount;
            while (tick > 0)
            {
                Thread.Sleep(this.Interval);
                tick--;
                this.OnTimeChanged(tick);
            }
        }

        protected void OnTimeChanged(int tick)
        {
            if (this.TimeChangedEvent != null)
            {
                var args = new TimeChangedEventArgs(tick);
                this.TimeChangedEvent(this, args); // eventa ni preprasta dirketno kam methoda da se izpalni
            }
        }
    }
}