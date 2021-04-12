using MessengerSample.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace MessengerSample
{
    public partial class ReceiverUserControl : UserControl
    {
        public ReceiverUserControl()
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
