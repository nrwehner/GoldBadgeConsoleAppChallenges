using System;
using _04_Company_Outings_Console_App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Company_Outings_Tests
{
    //Unit Tests - repo methods

    [TestClass]
    public class CompanyOutingsTests
    {
        [TestMethod]
        public void CostPerPersonTest()
        {
            Outing outing = new Outing(Outing.TypeOfOuting.Golf, 16, new DateTime(2019,7,10), 3000);
            Console.WriteLine(outing.CostPerPerson);
            Assert.AreEqual((double)3000 / (int)16, outing.CostPerPerson);
        }
        [TestMethod]
        public void AddOutingToRepoTest()
        {
            Outing outing = new Outing(Outing.TypeOfOuting.Golf, 16, new DateTime(2019, 7, 10), 3000);
            OutingRepo repo = new OutingRepo();
            Console.WriteLine(repo._outingRepo.Count);
            repo.AddOutingToRepo(outing);
            Console.WriteLine(repo._outingRepo.Count);
            Assert.AreEqual(1, repo._outingRepo.Count);
            Console.WriteLine(repo._outingRepo[0].OutingType);
        }
        [TestMethod]
        public void GetAllOutingsTest()
        {
            Outing outing = new Outing(Outing.TypeOfOuting.Golf, 16, new DateTime(2019, 7, 10), 3000);
            OutingRepo repo = new OutingRepo();
            repo.AddOutingToRepo(outing);
            Outing outingTwo = new Outing(Outing.TypeOfOuting.Bowling, 10, new DateTime(2019, 10, 31), 500);
            repo.AddOutingToRepo(outing);
            Console.WriteLine(repo.GetAllOutings()[1].OutingAttendance);
            Assert.AreEqual(2, repo.GetAllOutings().Count);
        }
    }
}
