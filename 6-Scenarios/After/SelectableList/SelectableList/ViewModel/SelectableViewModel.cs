using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace SelectableList.ViewModel
{
    public class SelectableViewModel : ViewModelBase
    {
        public const string IsExpandedPropertyName = "IsExpanded";

        private bool _isExpanded;

        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                Set(() => IsExpanded, ref _isExpanded, value);
            }
        }

        public const string IsSelectedPropertyName = "IsSelected";

        private bool _isSelected;

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (Set(() => IsSelected, ref _isSelected, value))
                {
                    if (!_isSelected)
                    {
                        var allItemsAreUnselected = true;

                        Messenger.Default.Send(
                            new IsItemSelectedMessage(
                                this,
                                result =>
                                {
                                    allItemsAreUnselected &= !result;
                                }));

                        if (allItemsAreUnselected)
                        {
                            IsExpanded = false;
                            Messenger.Default.Send(new ExpandMessage(this, false));
                        }
                    }
                }
            }
        }

        private RelayCommand _expandCollapseCommand;

        public RelayCommand ExpandCollapseCommand
        {
            get
            {
                return _expandCollapseCommand
                    ?? (_expandCollapseCommand = new RelayCommand(
                    () =>
                    {
                        IsExpanded = true;
                        IsSelected = true;
                        Messenger.Default.Send(new ExpandMessage(this, IsExpanded));
                    }));
            }
        }

        public SelectableViewModel()
        {
            Messenger.Default.Register<ExpandMessage>(
                this,
                msg =>
                {
                    if (msg.Sender != this)
                    {
                        IsExpanded = msg.Content;
                    }
                });

            Messenger.Default.Register<IsItemSelectedMessage>(
                this,
                msg => msg.Execute(IsSelected));
        }
    }
}
