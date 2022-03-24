using _4ChallengeFour.ChallengeFourClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _4ChallengeFourTests
{
    [TestClass]
    public class C4Tests
    {
        private C4Outings _outing;
        private C4OutingsRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new C4OutingsRepo();
            _outing = new C4Outings(EventType.AmusementPark, 23, new DateTime(2021, 7, 23), 45);
            _repo.AddNewEvent(_outing);
        }
        [TestMethod]
        public void AddOuting_ShouldReturnTrue()
        {
            C4Outings newOuting = new C4Outings();
            bool wasAdded = _repo.AddNewEvent(newOuting);
            Assert.IsTrue(wasAdded);
        }
    }
}
