using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace EventToCommandDataTrigger.Vm.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="Value" /> property's name.
        /// </summary>
        public const string ValuePropertyName = "Value";

        private int _value = -5;

        /// <summary>
        /// Sets and gets the Value property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                Set(ValuePropertyName, ref _value, value);
            }
        }

        private RelayCommand<string> _incDecCommand;

        /// <summary>
        /// Gets the IncDecCommand.
        /// </summary>
        public RelayCommand<string> IncDecCommand
        {
            get
            {
                return _incDecCommand
                    ?? (_incDecCommand = new RelayCommand<string>(
                                          sign =>
                                          {
                                              if (sign == "+")
                                              {
                                                  Value++;
                                              }
                                              else
                                              {
                                                  Value--;
                                              }
                                          }));
            }
        }
    }
}
