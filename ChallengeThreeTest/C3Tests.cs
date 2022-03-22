using ChallengeThree.ChallengeThreeClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThreeTest
{
    [TestClass]
    public class C3Tests
    {
        private C3Badges _badge;
        private C3BadgesRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new C3BadgesRepo();
            _badge = new C3Badges(1234, new List<string>
            {
                "A2",
                "B3",
                "C1"
            });
            _repo.AddNewBadge(_badge);
        }

        [TestMethod]
        public void AddNewBadge_ShouldReturnTrue()
        {
            C3Badges badge = new C3Badges();
            bool addResult = _repo.AddNewBadge(badge);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetAllBadges_ShouldContainContent()
        {
            Dictionary<int, List<string>> badges = _repo.GetAllBadges();
            bool dictionaryHasContents = badges.ContainsKey(1234);
            Assert.IsTrue(dictionaryHasContents);
        }

        [TestMethod]
        public void UpdateDoorAccess_ShouldReturnTrue()
        {
            bool wasUpdated = _repo.UpdateDoorInformation(1234, "A8");
            Assert.IsTrue(wasUpdated);
        }
        [TestMethod]
        public void RemoveDoorAccess_ShouldReturnTrue()
        {
            bool wasRemoved = _repo.RemoveDoorInformation(1234, "A2");
            Assert.IsTrue(wasRemoved);
        }
        [TestMethod]
        public void RemoveBadge_ShouldReturnTrue()
        {
            bool removeResult = _repo.RemoveBadge(1234);
            Assert.IsTrue(removeResult);
        }
    }
}
