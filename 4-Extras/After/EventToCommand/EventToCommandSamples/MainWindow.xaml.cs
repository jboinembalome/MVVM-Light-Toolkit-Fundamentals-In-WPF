using EventToCommandSamples.ViewModel;
using System.Windows;

namespace EventToCommandSamples
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}
