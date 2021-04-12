using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MessengerSample.Helpers;
using System;
using System.Windows;

namespace MessengerSample.ViewModel
{
    public class SenderViewModel : ViewModelBase
    {
        private RelayCommand<string> _sendCommand;
        private RelayCommand<string> _sendWithFeedbackCommand;

        public RelayCommand<string> SendCommand
        {
            get
            {
                return _sendCommand
                    ?? (_sendCommand = new RelayCommand<string>(
                        text =>
                        {
                            var message = new LogMessage(
                                text,
                                DateTime.Now);

                            Messenger.Default.Send(message);
                        }));
            }
        }

        public RelayCommand<string> SendWithFeedbackCommand
        {
            get
            {
                return _sendWithFeedbackCommand
                    ?? (_sendWithFeedbackCommand = new RelayCommand<string>(
                        text =>
                        {
                            var message = new LogMessageWithFeedback(
                                text,
                                DateTime.Now,
                                result =>
                                {
                                    MessageBox.Show(result ? "OK" : "Cancel");
                                });

                            Messenger.Default.Send(message);
                        }));
            }
        }
    }
}
