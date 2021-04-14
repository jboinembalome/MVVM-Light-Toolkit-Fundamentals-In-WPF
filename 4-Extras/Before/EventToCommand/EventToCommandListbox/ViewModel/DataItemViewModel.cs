using EventToCommandListbox.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace EventToCommandListbox.ViewModel
{
    public class DataItemViewModel : ViewModelBase
    {
        public DataItem Model
        {
            get;
            private set;
        }

        private RelayCommand _showItemCommand;

        /// <summary>
        /// Gets the ShowItemCommand.
        /// </summary>
        public RelayCommand ShowItemCommand
        {
            get
            {
                return _showItemCommand
                    ?? (_showItemCommand = new RelayCommand(
                                          () =>
                                          {
                                              MessageBox.Show(Model.Title);
                                          }));
            }
        }

        public DataItemViewModel(DataItem model)
        {
            Model = model;
        }
    }
}