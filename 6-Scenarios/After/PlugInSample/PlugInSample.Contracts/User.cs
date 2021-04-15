using GalaSoft.MvvmLight;

namespace PlugInSample.Contracts
{
    public class User : ObservableObject
    {
        public const string FirstNamePropertyName = "FirstName";
        public const string LastNamePropertyName = "LastName";

        private string _firstName = "First name";
        private string _lastName = "Last name";

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                Set(() => FirstName, ref _firstName, value);
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                Set(() => LastName, ref _lastName, value);
            }
        }
    }
}