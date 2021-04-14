using System;

namespace WhyMvvm.Helpers
{
    public interface INavigationService
    {
        void GoBack();
        void NavigateTo(Uri uri);
        void NavigateTo(Uri uri, object state);
    }
}
