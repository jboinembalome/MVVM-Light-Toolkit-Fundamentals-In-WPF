using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WhyMvvm
{
    public partial class DetailsPage : Window
    {
        public DetailsPage()
        {
            InitializeComponent();

            if (App.SelectedFriend != null)
            {
                FirstNameTextBox.Text = App.SelectedFriend.FirstName;
                LastNameTextBox.Text = App.SelectedFriend.LastName;

                PreviewFirstNameTextBlock.Text = App.SelectedFriend.FirstName;
                PreviewLastNameTextBlock.Text = App.SelectedFriend.LastName;
            }
        }

        private void FirstNameTextChanged(object sender, TextChangedEventArgs e)
        {
            App.SelectedFriend.FirstName = ((TextBox)sender).Text;
            PreviewFirstNameTextBlock.Text = App.SelectedFriend.FirstName;

        }

        private void LastNameTextChanged(object sender, TextChangedEventArgs e)
        {
            App.SelectedFriend.LastName = ((TextBox)sender).Text;
            PreviewLastNameTextBlock.Text = App.SelectedFriend.LastName;
        }

        private async void SaveClick(object sender, EventArgs e)
        {
            try
            {
                var service = new Model.FriendsService();
                var result = await service.Save(App.SelectedFriend);

                var id = result.Id;

                if (id > 0)
                {
                    App.SelectedFriend.Id = id;
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }

            this.Close();
        }
    }
}