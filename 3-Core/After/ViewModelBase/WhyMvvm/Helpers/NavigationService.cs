using System;
using System.Windows;

namespace WhyMvvm.Helpers
{
    public class NavigationService : INavigationService
    {
        private System.Windows.Navigation.NavigationService _mainFrame;

        public void GoBack()
        {
            if (EnsureMainFrame()
                && _mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
        }

        public void NavigateTo(Uri pageUri)
        {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(pageUri);
            }
        }

        private bool EnsureMainFrame()
        {
            if (_mainFrame != null)
            {
                return true;
            }
      
            _mainFrame = (Application.Current.MainWindow as MainWindow).Frame.NavigationService;
            return _mainFrame != null;
        }
    }
}
