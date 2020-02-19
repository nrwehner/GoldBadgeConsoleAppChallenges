using System;
using _02_Claims__Console_App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claims_Tests
{
    //5. Unit Tests - test all methods

    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void IsValidTests()
        {
            Claim claim = new Claim("ads",Claim.ClaimTypeOptions.Car,"descr",124d,new DateTime(2020,1,15),new DateTime(2020,2,2));
            Console.WriteLine(claim.IsValid);
            Assert.AreEqual(true, claim.IsValid);
            Assert.IsTrue(claim.IsValid);

            Claim claimTwo = new Claim("22", Claim.ClaimTypeOptions.Home, "descrtiption", 22234d, new DateTime(1995, 7, 4), new DateTime(1996, 1, 10));
            Console.WriteLine(claimTwo.IsValid);
            Assert.IsFalse(claimTwo.IsValid);
            Assert.AreEqual(false, claimTwo.IsValid);

            Claim claimThree = new Claim("dkjf", Claim.ClaimTypeOptions.Theft, "doodlydo", 89485, new DateTime(2004, 3, 1), new DateTime(2004, 3, 31));
            Console.WriteLine(claimThree.IsValid);
            Assert.IsTrue(claimThree.IsValid);
            Assert.AreEqual(true, claimThree.IsValid);
        }
        [TestMethod]
        public void AddClaimToRepoTests()
        {
            ClaimRepo repo = new ClaimRepo();
            Claim claim = new Claim("ads", Claim.ClaimTypeOptions.Car, "descr", 124d, new DateTime(2020, 1, 15), new DateTime(2020, 2, 2));
            Claim claimTwo = new Claim("22", Claim.ClaimTypeOptions.Home, "descrtiption", 22234d, new DateTime(1995, 7, 4), new DateTime(1996, 1, 10));
            Console.WriteLine(repo.AddClaimToRepo(claim)); 
            Console.WriteLine(repo._claimRepo.Count);
            Assert.IsTrue(repo.AddClaimToRepo(claimTwo));
            Assert.AreEqual(2, repo._claimRepo.Count);
            Console.WriteLine(repo._claimRepo.Count);
        }
        [TestMethod]
        public void GetAllClaimsTests()
        {
            ClaimRepo repo = new ClaimRepo();
            Claim claim = new Claim("ads", Claim.ClaimTypeOptions.Car, "descr", 124d, new DateTime(2020, 1, 15), new DateTime(2020, 2, 2));
            Claim claimTwo = new Claim("22", Claim.ClaimTypeOptions.Home, "descrtiption", 22234d, new DateTime(1995, 7, 4), new DateTime(1996, 1, 10));
            repo.AddClaimToRepo(claim);
            repo.AddClaimToRepo(claimTwo);
            Console.WriteLine(repo.GetAllClaims().Count);
            Console.WriteLine(repo.GetAllClaims());
            Assert.AreEqual(2, repo.GetAllClaims().Count);
        }
        /*[TestMethod]
        public void DeQueueNextClaimTests()
        {
            ClaimRepo repo = new ClaimRepo();
            Claim claim = new Claim("ads", Claim.ClaimTypeOptions.Car, "descr", 124d, new DateTime(2020, 1, 15), new DateTime(2020, 2, 2));
            Claim claimTwo = new Claim("22", Claim.ClaimTypeOptions.Home, "descrtiption", 22234d, new DateTime(1995, 7, 4), new DateTime(1996, 1, 10));
            repo.AddClaimToRepo(claim);
            repo.AddClaimToRepo(claimTwo);
            Console.WriteLine(repo.DeQueueNextClaim());
        }*/
        [TestMethod]
        public void MyTestMethod()
        {
            ClaimRepo repo = new ClaimRepo();
            repo._claimRepo.Peek();
        }
    }
}
