using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Linq;

namespace SelectableList.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _addItemCommand;

        public RelayCommand AddItemCommand
        {
            get
            {
                return _addItemCommand
                       ?? (_addItemCommand = new RelayCommand(
                           () =>
                           {
                               var expanded = Items.Any(i => i.IsExpanded);
                               var item = new ItemViewModel
                               {
                                   Title = "Item # " + (Items.Count + 1),
                                   IsExpanded = expanded
                               };

                               Items.Add(item);
                           }));
            }
        }

        public ObservableCollection<ItemViewModel> Items
        {
            get;
            set;
        }

        public MainViewModel()
        {
            Items = new ObservableCollection<ItemViewModel>
            {
                new ItemViewModel
                {
                    Title = "This is an item"
                },
                new ItemViewModel
                {
                    Title = "This is another item"
                },
            };
        }
    }
}