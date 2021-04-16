using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelectableList.ViewModel;
using System;
using System.Collections.Generic;

namespace SelectableList.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestExpansion()
        {
            Messenger.Reset();

            var list = new List<SelectableViewModel>();

            for (var index = 0; index < 5; index++)
            {
                list.Add(new SelectableViewModel());
            }

            list[0].ExpandCollapseCommand.Execute(null);

            foreach (var item in list)
            {
                Assert.IsTrue(item.IsExpanded);
            }

            Assert.IsTrue(list[0].IsSelected);
        }

        [TestMethod]
        public void TestCollapse()
        {
            Messenger.Reset();

            var list = new List<SelectableViewModel>();

            for (var index = 0; index < 5; index++)
            {
                list.Add(new SelectableViewModel());
            }

            list[0].ExpandCollapseCommand.Execute(null);
            list[1].IsSelected = true;

            list[0].IsSelected = false;

            foreach (var item in list)
            {
                Assert.IsTrue(item.IsExpanded);
            }

            list[1].IsSelected = false;

            foreach (var item in list)
            {
                Assert.IsFalse(item.IsExpanded);
            }
        }
    }
}
