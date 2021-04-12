using MessengerSample.ViewModel;
using System.Windows;

namespace MessengerSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddReceiverClick(object sender, RoutedEventArgs e)
        {
            ReceiversPanel.Children.Add(new ReceiverUserControl
            {
                DataContext = new ReceiverViewModel(false)
            });
        }

        private void RemoveReceiverClick(object sender, RoutedEventArgs e)
        {
            ReceiversPanel.Children.RemoveAt(ReceiversPanel.Children.Count - 1);
        }

        private void AddReceiverWithFeedbackClick(object sender, RoutedEventArgs e)
        {
            ReceiversPanel.Children.Add(new ReceiverWithFeedbackUserControl
            {
                DataContext = new ReceiverViewModel(true)
            });
        }
    }
}
