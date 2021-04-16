using System;

namespace UnitTestSample.Helpers
{
    public interface INavigationService
    {
        Uri CurrentUri
        {
            get;
        }

        void GoBack();
        void NavigateTo(Uri uri);
    }
}
