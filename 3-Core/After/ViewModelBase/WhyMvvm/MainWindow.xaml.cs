using System.Windows;

namespace WhyMvvm
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Frame.Content = new MainPage();
        }
    }
}
