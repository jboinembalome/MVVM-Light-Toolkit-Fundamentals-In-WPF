using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace EventToCommandDataTrigger.Vm.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _validateCommand;

        /// <summary>
        /// Gets the ValidateCommand.
        /// </summary>
        public RelayCommand ValidateCommand
        {
            get
            {
                return _validateCommand
                    ?? (_validateCommand = new RelayCommand(
                                          () =>
                                          {
                                              Result = "Command was executed";
                                          }));
            }
        }

        /// <summary>
        /// The <see cref="Result" /> property's name.
        /// </summary>
        public const string ResultPropertyName = "Result";

        private string _result = "Waiting...";
        /// <summary>
        /// Sets and gets the Result property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                Set(ResultPropertyName, ref _result, value);
            }
        }

        public MainViewModel()
        {
        }
    }
}
