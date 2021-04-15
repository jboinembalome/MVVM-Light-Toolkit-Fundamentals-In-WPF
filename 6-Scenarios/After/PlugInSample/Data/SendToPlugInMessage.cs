using GalaSoft.MvvmLight.Messaging;

namespace PlugInSample.Contracts
{
    public class SendToPlugInMessage : NotificationMessage<User>
    {
        public SendToPlugInMessage(object sender, User user, string notification)
            : base(sender, user, notification)
        {
        }
    }
}