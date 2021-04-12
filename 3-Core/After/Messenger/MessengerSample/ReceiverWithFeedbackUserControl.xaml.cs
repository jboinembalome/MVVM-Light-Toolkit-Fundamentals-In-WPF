using MessengerSample.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace MessengerSample
{
    public partial class ReceiverWithFeedbackUserControl : UserControl
    {
        public ReceiverWithFeedbackUserControl()
        {
            InitializeComponent();
            Unloaded += ReceiverUserControlUnloaded;
        }

        void ReceiverUserControlUnloaded(object sender, RoutedEventArgs e)
        {
            ((ReceiverViewModel)DataContext).Unload();
        }
    }
}
