namespace _4.AnonymousMethods
{
    using System;
    using System.Windows.Forms;

    internal class AnonymousMethods
    {
        private static void Main()
        {
            // Method syntax - nai-staria nachin, kadeto se pishe method
            Action<string> action = ShowMsg; 

            // Delegate syntax -malko po-nov nachin, no i toi e tromav
            action = delegate(string msg) { MessageBox.Show(msg); };

            // Lambda syntax -nai-novia nachin- ne ukazvame che e string msg, tai kato veche gore sem ukazali s  Action<string>
            action = msg => MessageBox.Show(msg);  // Action<string> action = msg => { MessageBox.Show(msg); };

            ////Action<string> action = ((msg) =>
            ////{
            ////    MessageBox.Show(msg);
            ////});

            action("Hello!");
        }

        private static void ShowMsg(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}