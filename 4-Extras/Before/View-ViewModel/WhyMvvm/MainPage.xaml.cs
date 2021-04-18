using System;
using System.Windows.Controls;
using WhyMvvm.ViewModel;

namespace WhyMvvm
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void RefreshClick(object sender, EventArgs e)
        {
            var vm = (MainViewModel)DataContext;
            vm.RefreshCommand.Execute(null);
        }
    }
}
