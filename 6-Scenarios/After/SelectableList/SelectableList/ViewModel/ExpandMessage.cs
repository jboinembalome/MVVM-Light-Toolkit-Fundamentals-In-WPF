using GalaSoft.MvvmLight.Messaging;

namespace SelectableList.ViewModel
{
    public class ExpandMessage : GenericMessage<bool>
    {
        public ExpandMessage(object sender, bool expand)
            : base(sender, expand)
        {
        }
    }
}
