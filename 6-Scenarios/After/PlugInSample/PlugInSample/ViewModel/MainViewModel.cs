using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using PlugInSample.Contracts;
using PlugInSample.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace PlugInSample.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private int _counterValue;

        private RelayCommand _refreshPlugInsCommand;

        public ObservableCollection<IPlugIn> PlugIns
        {
            get;
            private set;
        }

        public RelayCommand RefreshPlugInsCommand
        {
            get
            {
                return _refreshPlugInsCommand
                       ?? (_refreshPlugInsCommand = new RelayCommand(
                           () =>
                           {
                               PlugIns.Clear();

                               var host = ServiceLocator.Current.GetInstance<IPlugInHost>();
                               host.Clear();

                               var bootstrapper = ServiceLocator.Current.GetInstance<Bootstrapper>();

                               try
                               {
                                   bootstrapper.Refresh();
                               }
                               catch (Exception ex)
                               {
                                   MessageBox.Show(ex.Message);
                                   return;
                               }

                               foreach (var plugIn in bootstrapper.PlugIns)
                               {
                                   PlugIns.Add(plugIn);
                                   host.PlacePlugIn(plugIn, this);
                               }
                           }));
            }
        }

        /// <summary>
        /// The <see cref="Counter" /> property's name.
        /// </summary>
        public const string CounterPropertyName = "Counter";

        private string _counter = "Initializing";

        /// <summary>
        /// Sets and gets the Counter property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Counter
        {
            get
            {
                return _counter;
            }
            set
            {
                Set(() => Counter, ref _counter, value);
            }
        }

        private RelayCommand _incrementCounterCommand;

        /// <summary>
        /// Gets the IncrementCounterCommand.
        /// </summary>
        public RelayCommand IncrementCounterCommand
        {
            get
            {
                return _incrementCounterCommand
                    ?? (_incrementCounterCommand = new RelayCommand(
                        () =>
                        {
                            Counter = string.Format(
                                "Counter is now {0}",
                                _counterValue++);
                        }));
            }
        }

        public const string CurrentUserPropertyName = "CurrentUser";

        private User _currentUser = new User();

        public User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                Set(() => CurrentUser, ref _currentUser, value);
            }
        }

        private RelayCommand _sendUserCommand;

        public RelayCommand SendUserCommand
        {
            get
            {
                return _sendUserCommand
                       ?? (_sendUserCommand = new RelayCommand(
                           () => Messenger.Default.Send(
                               new NotificationMessage<User>(
                                   this,
                                   CurrentUser,
                                   Notifications.NewUserNotification))));
            }
        }

        public MainViewModel()
        {
            PlugIns = new ObservableCollection<IPlugIn>();

#if DEBUG
            if (IsInDesignMode)
            {
                CurrentUser = new User
                {
                    FirstName = "Laurent",
                    LastName = "Bugnion"
                };
            }
#endif
        }
    }
}