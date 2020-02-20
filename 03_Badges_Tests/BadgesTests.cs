using System;
using System.Collections.Generic;
using _03_Badges_Console_App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badges_Tests
{
    [TestClass]
    public class BadgesTests
    {
        [TestMethod]
        public void AddDoorToAccesListTest()
        {
            Badge badge = new Badge("123",new List<string>() {"b"});
            badge.DoorAccessList.Add("a1");
            Console.WriteLine(badge.DoorAccessList.Count);
            Assert.AreEqual(2, badge.DoorAccessList.Count);
            badge.AddDoorToAccessList("b2");
            Assert.AreEqual(3, badge.DoorAccessList.Count);
            Console.WriteLine(badge.DoorAccessList.Count);
        }
        [TestMethod]
        public void AddBadgeToRepoTest()
        {
            Badge badge = new Badge("123", new List<string>() { "b" });
            BadgeRepo repo = new BadgeRepo();
            repo.AddBadgeToRepo(badge);
            Console.WriteLine(repo._badgeRepo.Count);
            Assert.AreEqual(1, repo._badgeRepo.Count);
            Badge badgeTwo = new Badge("124",new List<string>() { "a" });
            repo.AddBadgeToRepo(badgeTwo);
            Console.WriteLine(repo._badgeRepo.Count);
            Assert.AreEqual(2, repo._badgeRepo.Count);
        }
        [TestMethod]
        public void DoesBadgeIDExistTest()
        {
            Badge badge = new Badge("123", new List<string>() { "b" });
            BadgeRepo repo = new BadgeRepo();
            repo.AddBadgeToRepo(badge);
            bool boolOne = repo.DoesBadgeIDExist("123");
            Assert.AreEqual(true, boolOne);
            Assert.IsTrue(repo.DoesBadgeIDExist("123"));
            bool boolTwo = repo.DoesBadgeIDExist("124");
            Assert.AreEqual(false, boolTwo);
            Assert.IsFalse(repo.DoesBadgeIDExist("124"));
        }
        [TestMethod]
        public void GetAllBadgesTest()
        {
            Badge badge = new Badge("123", new List<string>() { "b" });
            BadgeRepo repo = new BadgeRepo();
            repo.AddBadgeToRepo(badge);
            Badge badgeTwo = new Badge("124", new List<string>() { "b" });
            repo.AddBadgeToRepo(badgeTwo);
            Console.WriteLine(repo.GetAllBadges().Count); 
        }
        [TestMethod]
        public void GetBadgeByBadgeIDTest()
        {

        }
        [TestMethod]
        public void DeleteBadgeTest()
        {

        }
    }
}
