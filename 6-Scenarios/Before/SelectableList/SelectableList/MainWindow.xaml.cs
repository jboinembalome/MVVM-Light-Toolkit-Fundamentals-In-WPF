using SelectableList.ViewModel;
using System;
using System.Windows;

namespace SelectableList
{
    public partial class MainWindow : Window
    {
        public MainViewModel Vm
        {
            get
            {
                return (MainViewModel)DataContext;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddItemClick(object sender, EventArgs e)
        {
            Vm.AddItemCommand.Execute(null);
        }
    }
}
