using GalaSoft.MvvmLight.Messaging;
using System;

namespace SelectableList.ViewModel
{
    public class IsItemSelectedMessage : MessageBase
    {
        private readonly Action<bool> _callback;

        public IsItemSelectedMessage(object sender, Action<bool> callback)
            : base(sender)
        {
            _callback = callback;
        }

        public void Execute(bool result)
        {
            if (_callback != null)
            {
                _callback(result);
            }
        }
    }
}
