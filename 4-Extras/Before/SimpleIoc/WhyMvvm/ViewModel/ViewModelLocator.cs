using GalaSoft.MvvmLight;
using System.Windows;
using WhyMvvm.Design;
using WhyMvvm.Helpers;
using WhyMvvm.Model;

namespace WhyMvvm.ViewModel
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance
        {
            get
            {
                return Application.Current.Resources["Locator"] as ViewModelLocator;
            }
        }

        public MainViewModel Main
        {
            get;
            private set;
        }

        public ViewModelLocator()
        {
            IFriendsService friendsService;

            if (ViewModelBase.IsInDesignModeStatic)
            {
                friendsService = new DesignFriendsService();
            }
            else
            {
                friendsService = new FriendsService();
            }

            IDialogService dialogService = new DialogService();
            INavigationService navigationService = new NavigationService();

            Main = new MainViewModel(friendsService, dialogService, navigationService);
        }
    }
}
