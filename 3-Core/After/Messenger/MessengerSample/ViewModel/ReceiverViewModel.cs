using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MessengerSample.Helpers;
using System;

namespace MessengerSample.ViewModel
{
    public class ReceiverViewModel : ViewModelBase
    {
        public const string DisplayPropertyName = "Display";

        private Action<bool> _feedback;
        private string _display = string.Empty;
        private RelayCommand<string> _sendFeedbackCommand;

        public string Display
        {
            get
            {
                return _display;
            }
            set
            {
                Set(DisplayPropertyName, ref _display, value);
            }
        }

        public RelayCommand<string> SendFeedbackCommand
        {
            get
            {
                return _sendFeedbackCommand
                    ?? (_sendFeedbackCommand = new RelayCommand<string>(
                                          result =>
                                          {
                                              if (_feedback != null)
                                              {
                                                  _feedback(result == "1");
                                              }
                                          }));
            }
        }

        public ReceiverViewModel(bool useCallback)
        {
            if (useCallback)
            {
                Messenger.Default.Register<LogMessageWithFeedback>(
                    this,
                    message =>
                    {
                        var display = string.Format(
                            "Message: {0} sent on {1:G}",
                            message.Text,
                            message.Timestamp);

                        Display = display;
                        _feedback = message.Feedback;
                    });
            }
            else
            {
                Messenger.Default.Register<LogMessage>(
                    this,
                    message =>
                    {
                        var display = string.Format(
                            "Message: {0} sent on {1:G}",
                            message.Text,
                            message.Timestamp);

                        Display = display;
                    });
            }
        }

        public void Unload()
        {
            Messenger.Default.Unregister<LogMessage>(this);
            Messenger.Default.Unregister<LogMessageWithFeedback>(this);
        }
    }
}
