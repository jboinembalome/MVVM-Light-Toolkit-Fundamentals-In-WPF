using System;
using System.Collections.Generic;
using System.Windows;

namespace WhyMvvm.Helpers
{
    public class NavigationService : INavigationService
    {
        private const string QueryUriKey = "userstate";

        private static Dictionary<string, object> _userStates;
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

        public void NavigateTo(Uri pageUri, object state)
        {
            if (EnsureMainFrame())
            {
                Uri newUri;

                lock (_userStates)
                {
                    string id = Guid.NewGuid().ToString();
                    _userStates.Add(id, state);

                    if (pageUri.OriginalString.IndexOf("?") < 0)
                    {
                        newUri = new Uri(
                            string.Format(
                                "{0}?{1}={2}",
                                pageUri.OriginalString,
                                QueryUriKey,
                                id),
                            pageUri.IsAbsoluteUri ? UriKind.Absolute : UriKind.Relative);
                    }
                    else
                    {
                        newUri = new Uri(
                            string.Format(
                                "{0}&{1}={2}",
                                pageUri.OriginalString,
                                QueryUriKey,
                                id),
                            pageUri.IsAbsoluteUri ? UriKind.Absolute : UriKind.Relative);
                    }
                }

                NavigateTo(newUri);
            }
        }

        public static object GetAndRemoveState(IDictionary<string, string> query)
        {
            lock (_userStates)
            {
                if (query.ContainsKey(QueryUriKey)
                    && _userStates.ContainsKey(query[QueryUriKey]))
                {
                    object state = _userStates[query[QueryUriKey]];
                    _userStates.Remove(query[QueryUriKey]);
                    return state;
                }

                return null;
            }
        }

        private bool EnsureMainFrame()
        {
            if (_mainFrame != null)
            {
                return true;
            }
      
            _mainFrame = (Application.Current.MainWindow as MainWindow).Frame.NavigationService;
            _userStates = new Dictionary<string, object>();
            return _mainFrame != null;
        }
    }
}
