using System;
using _02_Claims__Console_App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claims_Tests
{
    //5. Unit Tests - test all methods          DONE

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
            Console.WriteLine(repo.AddClaimToRepo(claim)); //true
            Console.WriteLine(repo._claimRepo.Count); //1
            Assert.IsTrue(repo.AddClaimToRepo(claimTwo));
            Assert.AreEqual(2, repo._claimRepo.Count);
            Console.WriteLine(repo._claimRepo.Count);//2
        }
        [TestMethod]
        public void GetAllClaimsTests()
        {
            ClaimRepo repo = new ClaimRepo();
            Claim claim = new Claim("ads", Claim.ClaimTypeOptions.Car, "descr", 124d, new DateTime(2020, 1, 15), new DateTime(2020, 2, 2));
            Claim claimTwo = new Claim("22", Claim.ClaimTypeOptions.Home, "descrtiption", 22234d, new DateTime(1995, 7, 4), new DateTime(1996, 1, 10));
            repo.AddClaimToRepo(claim);
            repo.AddClaimToRepo(claimTwo);
            Console.WriteLine(repo.GetAllClaims().Count);//2
            Console.WriteLine(repo.GetAllClaims());//some reference
            Assert.AreEqual(2, repo.GetAllClaims().Count);
        }
        [TestMethod]
        public void DisplayNextClaimTests()
        {
            ClaimRepo repo = new ClaimRepo();
            Claim claim = new Claim("ads", Claim.ClaimTypeOptions.Car, "descr", 124d, new DateTime(2020, 1, 15), new DateTime(2020, 2, 2));
            Claim claimTwo = new Claim("22", Claim.ClaimTypeOptions.Home, "descrtiption", 22234d, new DateTime(1995, 7, 4), new DateTime(1996, 1, 10));
            repo.AddClaimToRepo(claim);
            repo.AddClaimToRepo(claimTwo);
            Assert.AreEqual(2, repo._claimRepo.Count);
            repo.DisplayNextClaim();
            Assert.AreEqual(2, repo._claimRepo.Count);
            bool result = repo.DisplayNextClaim();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void DisplayNextWhenVoidTests()
        {
            ClaimRepo repo = new ClaimRepo();
            Assert.AreEqual(0, repo._claimRepo.Count);
            bool result = repo.DisplayNextClaim();
            Assert.IsFalse(result);
        }
    }
}
