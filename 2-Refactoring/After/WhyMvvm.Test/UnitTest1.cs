using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhyMvvm.Helpers;
using WhyMvvm.Model;
using WhyMvvm.ViewModel;

namespace WhyMvvm.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestShowingErrorWhenSaving()
        {
            var dialogService = new TestDialogService();

            var vm = new MainViewModel(
                new TestFriendsService(),
                dialogService,
                new TestNavigationService());

            Assert.IsNull(
                dialogService.MessageShown);

            vm.SaveCommand.Execute(new Friend
            {
                Id = 1
            });

            Assert.AreEqual(
                TestFriendsService.ErrorMessage,
                dialogService.MessageShown);
        }

    }


    public class TestFriendsService : IFriendsService
    {
        public const string ErrorMessage = "This is a test error message";

        public Task<IEnumerable<Friend>> Refresh()
        {
            return Task.FromResult(Enumerable.Empty<Friend>());
        }

        public Task<Friend> Save(Friend updatedFriend)
        {
            throw new Exception(ErrorMessage);
        }

    }

    public class TestDialogService : IDialogService
    {
        public string MessageShown
        {
            get;
            private set;
        }

        public void ShowMessage(string message)
        {
            MessageShown = message;
        }

    }

    public class TestNavigationService : INavigationService
    {
        public void GoBack()
        {
        }

        public void NavigateTo(Uri uri)
        {
        }

    }
}
