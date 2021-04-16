using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using UnitTestSample;
using UnitTestSample.Helpers;
using UnitTestSample.Model;
using UnitTestSample.ViewModel;

namespace UnitTestLibrary1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var nav = new TestNavigationService();
            var data = new TestDataService();

            const string testProp1 = "this is a test";
            const int testProp2 = 1234;

            data.Initialize(testProp1, testProp2);

            var vm = new MainViewModel(data, nav);

            Assert.AreEqual(
                string.Format("{0} / {1}", testProp1, testProp2),
                vm.WelcomeTitle);
        }

        [TestMethod]
        public void TestNavigation()
        {
            var nav = new TestNavigationService();
            var data = new TestDataService();

            var vm = new MainViewModel(data, nav);

            vm.NavigateCommand.Execute(null);

            Assert.AreEqual(new Uri("SecondPage.xaml", UriKind.Relative), nav.CurrentUri);
        }

        [TestMethod]
        public void TestWelcomeTitle()
        {
            var nav = new TestNavigationService();
            var data = new TestDataService();

            var vm = new MainViewModel(data, nav);

            var propertyChangedWasRaised = false;

            vm.PropertyChanged += (s, e) =>
            {
                propertyChangedWasRaised = true;
            };

            Assert.IsFalse(propertyChangedWasRaised);

            vm.WelcomeTitle = "This is a new value";

            Assert.IsTrue(propertyChangedWasRaised);
        }
    }

    public class TestNavigationService : INavigationService
    {
        public Uri CurrentUri
        {
            get;
            private set;
        }

        public void GoBack()
        {
        }

        public void NavigateTo(Uri uri)
        {
            CurrentUri = uri;
        }
    }

    public class TestDataService : IDataService
    {
        private string _prop1;
        private int _prop2;

        public void Initialize(string prop1, int prop2)
        {
            _prop1 = prop1;
            _prop2 = prop2;
        }

        public Task<DataItem> GetData()
        {
            var item = new DataItem
            {
                Property1 = _prop1,
                Property2 = _prop2
            };

            return Task.FromResult(item);
        }
    }
}
