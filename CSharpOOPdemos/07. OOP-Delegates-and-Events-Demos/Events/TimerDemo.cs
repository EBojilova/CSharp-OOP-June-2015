namespace _6.Events
{
    using System;

    public class TimerDemo
    {
        public static void Main()
        {
            var timer = new Timer(10, 1000);
            timer.TimeChangedEvent += TimeChangedMethod; // podavame na eventa method

            Console.WriteLine("Timer started for 10 ticks at interval 1000 ms.");
            timer.Run();
        }

        private static void TimeChangedMethod(object sender, TimeChangedEventArgs eventArgs)
        {
            Console.WriteLine("{0}! Ticks left = {1}", sender.GetType().Name, eventArgs.TicksLeft);
        }
    }
}