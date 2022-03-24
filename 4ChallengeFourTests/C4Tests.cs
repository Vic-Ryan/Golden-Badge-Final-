using _4ChallengeFour.ChallengeFourClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _4ChallengeFourTests
{
    [TestClass]
    public class C4Tests
    {
        private C4Outings _outing;
        private C4Outings _outing2;
        private C4Outings _outing3;
        private C4OutingsRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new C4OutingsRepo();
            _outing = new C4Outings(EventType.AmusementPark, 23, new DateTime(2021, 7, 23), 45);
            _outing2 = new C4Outings(EventType.AmusementPark, 42, new DateTime(2019, 6, 14), 38);
            _outing3 = new C4Outings(EventType.Golf, 2, new DateTime(2022, 8, 24), 5);
            _repo.AddNewEvent(_outing);
            _repo.AddNewEvent(_outing2);
            _repo.AddNewEvent(_outing3);
        }
        [TestMethod]
        public void AddOuting_ShouldReturnTrue()
        {
            C4Outings newOuting = new C4Outings();
            bool wasAdded = _repo.AddNewEvent(newOuting);
            Assert.IsTrue(wasAdded);
        }
        [TestMethod]
        public void RemoveOuting_ShouldReturnTrue()
        {

            bool wasRemoved = _repo.RemoveEvent(_outing);
            Assert.IsTrue(wasRemoved);
        }
        [TestMethod]
        public void GetAllOutings_ShouldContainContent()
        {
            List<C4Outings> listOfOutings = _repo.GetAllOutings();
            bool hasContents = listOfOutings.Contains(_outing);
            Assert.IsTrue(hasContents);
        }
        [TestMethod]
        public void GetOutingByType_ShouldReturnTrue()
        {
            EventType eventType = EventType.Golf;
            var hasEvent = _repo.GetOutingByType(eventType);
            Assert.AreEqual(hasEvent, _outing3);
        }
        [TestMethod]
        public void TotalCostSet_ShouldReturnTrue()
        {
            C4Outings newOuting = _outing;
            decimal totalCost = newOuting.TotalCost;
            Assert.AreEqual(totalCost, 1035m); //23 * 45 = 1035
        }
        [TestMethod]
        public void GetTotalCostOfAllOutings_ShouldBeEqual()
        {
            List<C4Outings> listOfOutings = _repo.GetAllOutings();
            decimal totalCost = 0m;
            foreach (C4Outings outing in listOfOutings)
            {
                totalCost = totalCost + outing.TotalCost;
            }
            Assert.AreEqual(totalCost, 2641m); //42 * 38 = 1569 + 1035 = 2631 + 10 = 2641
        }
        [TestMethod]
        public void GetTotalCostOfTypeOfOuting_ShouldBeEqual()
        {
            EventType eventType = EventType.AmusementPark;
            decimal totalCost = 0;
            List<C4Outings> listOfOutings = _repo.GetAllOutings();
            foreach (C4Outings outing in listOfOutings)
            {
                if (outing.EventType == eventType)
                {
                    totalCost = totalCost + outing.TotalCost;
                }
            }
            Assert.AreEqual(totalCost, 2631m); //Should only be the last two, 1569 + 1035 = 2631
        }
    }
}
