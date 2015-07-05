namespace UIApplication
{
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            this.MouseDown += this.MainWindow_MouseClick; // event: ima strashno mnogo vgradeni eventi- poiaviavat se kato svetkavica kato natisnem this.
            
            var button = (Button)this.FindName("DownloadButton");
            button.Click += this.Button_Click; //event
        }

        private void MainWindow_MouseClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(
                string.Format(
                    "Mouse clicked at ({0}, {1})", 
                    e.MouseDevice.GetPosition(this).X, 
                    e.MouseDevice.GetPosition(this).Y));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)this.FindName("UrlBox");
            var url = textBox.Text;

            var progress = (Label)this.FindName("Progress");

            using (var client = new WebClient())
            {
                progress.Content = "Downloading...";
                await client.DownloadFileTaskAsync(url, "../../site.html");

                progress.Content = "Done!";
            }
        }
    }
}