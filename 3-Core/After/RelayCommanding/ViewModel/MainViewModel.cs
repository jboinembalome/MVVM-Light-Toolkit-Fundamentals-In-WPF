using GalaSoft.MvvmLight.CommandWpf;
using System.ComponentModel;
using System.Windows;

namespace RelayCommanding.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Counter
        public const string CounterPropertyName = "Counter";

        private int _counter;

        public int Counter
        {
            get
            {
                return _counter;
            }

            set
            {
                if (_counter == value)
                {
                    return;
                }

                _counter = value;
                RaisePropertyChanged(CounterPropertyName);
                SayHelloCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        public RelayCommand<string> SayHelloCommand
        {
            get;
            private set;
        }

        public MainViewModel()
        {
            SayHelloCommand = new RelayCommand<string>(
                ShowMessage,
                m => _counter % 2 == 0);

            #region Hidden

            IncreaseCounterCommand = new RelayCommand(() =>
            {
                Counter++;
            });

            #endregion
        }

        private void ShowMessage(string parameter)
        {
            MessageBox.Show("Hello, " + parameter);
        }

        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Hidden

        public RelayCommand IncreaseCounterCommand
        {
            get;
            private set;
        }

        #endregion
    }
}
