using CommonServiceLocator;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WhyMvvm.Helpers;
using WhyMvvm.ViewModel;

namespace WhyMvvm
{
    public partial class DetailsPage : Page
    {
        public DetailsPage()
        {
            InitializeComponent();
            System.Windows.Navigation.NavigationService _mainFrame = (Application.Current.MainWindow as MainWindow).Frame.NavigationService;
            var state = Helpers.NavigationService.GetAndRemoveState(_mainFrame.Source.ParseQueryString());
            DataContext = state;
        }

        

        private void SaveClick(object sender, EventArgs e)
        {
            UpdateBinding();

            var mainVm = ServiceLocator.Current.GetInstance<MainViewModel>();
            mainVm.SaveCommand.Execute(DataContext);
        }

        private void UpdateBinding()
        {
            if (FocusManager.GetFocusedElement(this) is TextBox textbox)
            {
                var binding = textbox.GetBindingExpression(TextBox.TextProperty);
                binding.UpdateSource();
            }
        }
    }
}