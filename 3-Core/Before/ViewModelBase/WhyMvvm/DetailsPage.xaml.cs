using System;
using System.Windows.Controls;
using System.Windows.Input;
using WhyMvvm.ViewModel;

namespace WhyMvvm
{
    public partial class DetailsPage : Page
    {
        public DetailsPage()
        {
            InitializeComponent();
        }
        private void SaveClick(object sender, EventArgs e)
        {
            UpdateBinding();

            var vm = (MainViewModel)DataContext;
            vm.SaveCommand.Execute(vm.SelectedFriend);
        }

        private void UpdateBinding()
        {
            var textbox = FocusManager.GetFocusedElement(this) as TextBox;
            if (textbox != null)
            {
                var binding = textbox.GetBindingExpression(TextBox.TextProperty);
                binding.UpdateSource();
            }
        }
    }
}