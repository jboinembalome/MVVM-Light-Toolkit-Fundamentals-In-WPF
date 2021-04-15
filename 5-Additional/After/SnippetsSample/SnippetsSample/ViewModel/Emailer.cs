using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace SnippetsSample.ViewModel
{
    public class Emailer
    {
        public Emailer()
        {
            Messenger.Default.Register<PropertyChangedMessage<int>>(
                this,
                message =>
                {
                    if (message.Sender is MainViewModel
                        && message.PropertyName == MainViewModel.AgePropertyName)
                    {
                        // Send an email congratulating for the birthday

                        MessageBox.Show(string.Format("Your new age is {0}", message.NewValue));
                    }
                });
        }
    }
}
