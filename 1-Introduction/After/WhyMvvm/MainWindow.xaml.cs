using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WhyMvvm.Model;

namespace WhyMvvm
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void RefreshClick(object sender, RoutedEventArgs e)
        {
            var service = new FriendsService();
            var list = (await service.Refresh()).ToList();

            List.ItemsSource = list;

        }

        private void ListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Friend friend = List.SelectedItem as Friend;

            if (friend == null)
                return;

            App.SelectedFriend = friend;
            new DetailsPage().Show();
        }
    }
}
