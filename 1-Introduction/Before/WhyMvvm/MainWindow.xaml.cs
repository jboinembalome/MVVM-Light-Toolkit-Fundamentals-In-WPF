using System.Windows;
using System.Windows.Controls;

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
