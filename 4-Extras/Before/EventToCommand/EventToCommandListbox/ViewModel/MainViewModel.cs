using EventToCommandListbox.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace EventToCommandListbox.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Refresh();
        }

        private async Task Refresh()
        {
            Items = new ObservableCollection<DataItemViewModel>();

            _dataService.GetData(
                items =>
                {
                    foreach (var item in items)
                    {
                        Items.Add(new DataItemViewModel(item));
                    }
                });

        }

        public ObservableCollection<DataItemViewModel> Items
        {
            get;
            private set;
        }

        private RelayCommand<DataItemViewModel> _showItemCommand;

        /// <summary>
        /// Gets the ShowItemCommand.
        /// </summary>
        public RelayCommand<DataItemViewModel> ShowItemCommand
        {
            get
            {
                return _showItemCommand
                    ?? (_showItemCommand = new RelayCommand<DataItemViewModel>(
                        item =>
                        {
                            var message = string.Format("In MainVM: {0}", item.Model.Title);
                            MessageBox.Show(message);
                        }));
            }
        }
    }
}