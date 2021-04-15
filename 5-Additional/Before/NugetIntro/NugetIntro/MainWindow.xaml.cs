using System;
using System.Net;
using System.Windows;

namespace NugetIntro
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadJsonClick(object sender, RoutedEventArgs e)
        {
            var client = new WebClient();

            client.DownloadStringCompleted += ClientDownloadStringCompleted;
            client.DownloadStringAsync(new Uri("https://localhost:44376/api/nugetintro"));
        }

        private void ClientDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null
                && !string.IsNullOrEmpty(e.Result))
            {
                try
                {
                    // TODO Deserialize
                }
                catch
                {

                }
            }
        }
    }

    public class MyClass
    {
        public string Property1
        {
            get;
            set;
        }

        public int Property2
        {
            get;
            set;
        }
    }
}
