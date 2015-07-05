namespace _7.EventHandlerDemo
{
    using System;

    public class ButtonExample
    {
        public static void Main()
        {
            var button = new Button();
            button.Click += Button_Click; // prisvoiavam na eventa method
            button.FireClick(); // po princip ne triabva ot tuka da se vika eventa a ot operacionnata sistema, no za da se pokaje deistvieto na eventa simulirame klikane
        }

        private static void Button_Click(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Button_Click() event called.");
        }
    }
}