using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using PlugInSample.Contracts;
using System;
using System.Windows;

namespace PlugIn1.ViewModel
{
    public class PartialViewModel : ViewModelBase
    {
        public const string UserFullNamePropertyName = "UserFullName";

        private string _userFullName = "No user yet";

        public string UserFullName
        {
            get
            {
                return _userFullName;
            }
            set
            {
                Set(() => UserFullName, ref _userFullName, value);
            }
        }

        public IDataService DataService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IDataService>();
            }
        }

        private RelayCommand _callDataServiceCommand;

        /// <summary>
        /// Gets the CallDataServiceCommand.
        /// </summary>
        public RelayCommand CallDataServiceCommand
        {
            get
            {
                return _callDataServiceCommand
                    ?? (_callDataServiceCommand = new RelayCommand(
                        async () =>
                        {
                            try
                            {
                                var instance = await DataService.GetTestObject();

                                MessageBox.Show(
                                    string.Format(
                                        "{0} : {1}",
                                        instance.Property1,
                                        instance.Property2));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }));
            }
        }

        public PartialViewModel()
        {
            Messenger.Default.Register<NotificationMessage>(
                this,
                HandleNotification);

            Messenger.Default.Register<NotificationMessage<User>>(
                this,
                message =>
                {
                    if (message.Notification == Notifications.NewUserNotification)
                    {
                        UserFullName = string.Format(
                            "{0}, {1}",
                            message.Content.LastName,
                            message.Content.FirstName);
                    }
                });
        }

        private void HandleNotification(NotificationMessage message)
        {
            if (message.Notification == Notifications.CleanupNotification)
            {
                Messenger.Default.Unregister(this);
            }
        }
    }
}
