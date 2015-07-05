namespace _7.EventHandlerDemo
{
    using System;

    public class Button
    {
        public event EventHandler Click; // vavejdam event

        // public event EventHandler GotFocus;
        // public event EventHandler TextChanged;
        public void FireClick() // po princip ne triabva ot tuka da se vika eventa a ot operacionnata sistema, no za da se pokaje deistvieto na eventa simulirame klikane
        {
            this.OnClick();
        }

        protected void OnClick()
        {
            if (this.Click != null) // mnogo e vajno da se pravi tazi proverka, za da ne se hvarlia null exeption, t.e proverka dali na iventa e podaden method
            {
                this.Click(this, new EventArgs()); // izvikva se eventa na tozi klas this, bez argumetni new EvenArgs()
            }
        }
    }
}