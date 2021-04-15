using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;

namespace SnippetsSample.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="Status" /> property's name.
        /// </summary>
        public const string StatusPropertyName = "Status";

        private string _status = "Starting up";

        /// <summary>
        /// Sets and gets the Status property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Status
        {
            get
            {
                return _status;
            }

            set
            {
                if (_status == value)
                {
                    return;
                }

                _status = value;
                RaisePropertyChanged(StatusPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="FirstName" /> property's name.
        /// </summary>
        public const string FirstNamePropertyName = "FirstName";

        private string _firstName = "n/a";

        /// <summary>
        /// Sets and gets the FirstName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                if (_firstName == value)
                {
                    return;
                }

                _firstName = value;
                RaisePropertyChanged(() => FirstName);
            }
        }

        /// <summary>
        /// The <see cref="LastName" /> property's name.
        /// </summary>
        public const string LastNamePropertyName = "LastName";

        private string _lastName = "n/a";

        /// <summary>
        /// Sets and gets the LastName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                Set(LastNamePropertyName, ref _lastName, value);
            }
        }

        /// <summary>
        /// The <see cref="Age" /> property's name.
        /// </summary>
        public const string AgePropertyName = "Age";

        private int _age = 42;

        /// <summary>
        /// Sets and gets the Age property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                Set(() => Age, ref _age, value, true);
            }
        }

        private RelayCommand _showFullNameCommand;

        /// <summary>
        /// Gets the ShowFullName.
        /// </summary>
        public RelayCommand ShowFullNameCommand
        {
            get
            {
                return _showFullNameCommand
                    ?? (_showFullNameCommand = new RelayCommand(
                                          () =>
                                          {
                                              MessageBox.Show(
                                                  string.Format("{0}, {1}", LastName, FirstName));
                                          }));
            }
        }

        private RelayCommand<string> _sendEmailCommand;

        /// <summary>
        /// Gets the SendEmailCommand.
        /// </summary>
        public RelayCommand<string> SendEmailCommand
        {
            get
            {
                return _sendEmailCommand
                    ?? (_sendEmailCommand = new RelayCommand<string>(
                                          emailInput =>
                                          {
                                              // Send email
                                          },
                                          emailInput => !string.IsNullOrEmpty(emailInput)));
            }
        }
    }
}