using ChallengeTwo.C2Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeTwoTests
{
    [TestClass]
    public class C2Tests
    {
        private C2Claims _claim;
        private C2ClaimsRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new C2ClaimsRepo();
            _claim = new C2Claims(1, ClaimType.Car, "Test Claim", 500.00m, new DateTime(2022, 3, 21), new DateTime(2022, 2, 28));

            _repo.AddNewClaim(_claim);
        }

        [TestMethod]
        public void AddNewClaim_ShouldReturnTrue()
        {
            C2Claims claim = new C2Claims();
            bool addResult = _repo.AddNewClaim(claim);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetAllClaims_ShouldHaveContents()
        {
            List<C2Claims> contents = _repo.GetAllClaims();
            bool directoryHasContents = contents.Contains(_claim);
            Assert.IsTrue(directoryHasContents);
        }

        [TestMethod]
        public void GetFirstClaim_ShouldReturnCorrectClaim()
        {
            C2Claims claim = _repo.GetFirstClaim();
            Assert.AreEqual(_claim, claim);
        }

        [TestMethod]
        public void ValidClaim_ShouldReturnTrue()
        {
            Assert.IsTrue(_claim.IsValid);
        }

        [TestMethod]
        public void InvalidClaim_ShouldReturnFalse()
        {
            C2Claims invalidClaim = new C2Claims(2, ClaimType.Home, "Testing Validity", 2.00m, new DateTime(1999, 3, 21), new DateTime(2022, 3, 21));
            Assert.IsFalse(invalidClaim.IsValid);
        }

        [TestMethod]
        public void DeleteClaim_ShouldReturnTrue()
        {
            bool removeClaim = _repo.RemoveClaim(_claim);
            Assert.IsTrue(removeClaim);
        }
    }
}
