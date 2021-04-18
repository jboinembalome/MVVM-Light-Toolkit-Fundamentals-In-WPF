using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace NugetLibsOnly
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                Messenger.Default.Send(new NotificationMessage("MainPageLoaded"));
            };
        }
    }
}
