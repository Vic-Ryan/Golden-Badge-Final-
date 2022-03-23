using ChallengeOneConsole.ChallengeOneClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeOneTests
{
    [TestClass]
    public class C1Tests
    {
        private C1Menu _menuItem;
        private C1MenuRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new C1MenuRepo();
            _menuItem = new C1Menu(10, "Name", "Desc", "Ingr", 1.00m);

            _repo.AddNewMenuItem(_menuItem);
        }

        [TestMethod]
        public void AddMenuItem_ShouldReturnTrue()
        {
            bool addResult = _repo.AddNewMenuItem(_menuItem);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenuContents_ShouldReturnCorrectCollection()
        {
            _repo.AddNewMenuItem(_menuItem);
            List<C1Menu> contents = _repo.GetAllItems();
            bool directoryHasContents = contents.Contains(_menuItem);
            Assert.IsTrue(directoryHasContents);
        }

        [TestMethod]
        public void GetByNumber_ShouldReturnCorrectItem()
        {
            C1Menu searchResult = _repo.GetItemByNumber(10);
            Assert.AreEqual(_menuItem, searchResult);

        }

        [TestMethod]
        public void DeleteMenuItems_ShouldRemoveSpecifiedItem()
        {
            C1Menu menuItem = _repo.GetItemByNumber(10);
            bool removeResult = _repo.RemoveMenuItem(menuItem);
            Assert.IsTrue(removeResult);
        }
    }
}
