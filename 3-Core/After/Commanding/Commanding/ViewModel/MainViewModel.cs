using GalaSoft.MvvmLight.CommandWpf;
using System.ComponentModel;

namespace Commanding.ViewModel
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
            }
        }
        #endregion

        public SayHello SayHelloCommand
        {
            get;
            private set;
        }

        public MainViewModel()
        {
            SayHelloCommand = new SayHello(this);

            #region Hidden

            IncreaseCounterCommand = new RelayCommand(() =>
            {
                Counter++;
            });

            #endregion
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
