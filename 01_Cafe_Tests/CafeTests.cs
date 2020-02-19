using System;
using System.Collections.Generic;
using _01_Cafe_Console_App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_Tests
{
    /*4) Create a Test Class for your repository methods.                           DONE
     * (You don't need to test your constructors or objects, just your methods)
     */

    [TestClass]
    public class CafeTests
    {
        /*[TestMethod]
        public void AddIngredients()
        {
            MenuItem menuItem = new MenuItem("1", "Meal One", "it is delicious", new List<string>() { "onsdfdse","two","three" }, "3.95");
            Console.WriteLine(menuItem.IngredientList[0]+" "+menuItem.IngredientList[1]);
            Console.WriteLine(menuItem.IngredientList.Count);
            Assert.AreEqual(3, menuItem.IngredientList.Count);
            menuItem.AddIngredient("pickles");
            Console.WriteLine(menuItem.IngredientList[0]+" "+menuItem.IngredientList[1]+" "+menuItem.IngredientList[2]+" "+menuItem.IngredientList[3]);
            Console.WriteLine(menuItem.IngredientList.Count);
            Assert.AreEqual(4, menuItem.IngredientList.Count);
        }*/
        [TestMethod]
        public void AddNewMenuItemTest()
        {
            Repo repo = new Repo();
            MenuItem menuItem = new MenuItem("1", "Meal One", "description", "tomato, pickle", "3.95");
            Console.WriteLine(repo.AddNewMenuItem(menuItem));
            Console.WriteLine(repo._menuRepo.Count);
            Console.WriteLine(repo._menuRepo[0].Description);
            Assert.AreEqual(1, repo._menuRepo.Count);
        }
        [TestMethod]
        public void GetAllMenuItemsTest()
        {
            Repo repo = new Repo();
            MenuItem menuItem = new MenuItem("1", "Meal One", "description", "tomato, pickle", "3.95");
            MenuItem menuItemTwo = new MenuItem("2", "Meal Two", "description", "tomato, pickle", "3.85");
            repo.AddNewMenuItem(menuItem);
            repo.AddNewMenuItem(menuItemTwo);
            Console.WriteLine(repo.GetAllMenuItems().Count);
            Console.WriteLine($"{repo.GetAllMenuItems()[0].MealName} {repo.GetAllMenuItems()[1].MealName}");
            Assert.AreEqual(2, repo.GetAllMenuItems().Count);
        }
        [TestMethod]
        public void GetMenuItemByMealNumberTest()
        {
            Repo repo = new Repo();
            MenuItem menuItem = new MenuItem("1", "Meal One", "description", "tomato, pickle", "3.95");
            MenuItem menuItemTwo = new MenuItem("2", "Meal Two", "description", "tomato, pickle", "3.85");
            repo.AddNewMenuItem(menuItem);
            repo.AddNewMenuItem(menuItemTwo);
            Console.WriteLine($"{repo.GetMenuItemByMealNumber("1").MealNumber} {repo.GetMenuItemByMealNumber("1").MealName} " +
                $"{repo.GetMenuItemByMealNumber("1").Description} {repo.GetMenuItemByMealNumber("1").Price}");
            Assert.AreEqual("Meal One",repo.GetMenuItemByMealNumber("1").MealName);
            Assert.AreEqual("Meal Two", repo.GetMenuItemByMealNumber("2").MealName);
        }
        [TestMethod]
        public void DeleteMenuItemTest()
        {
            Repo repo = new Repo();
            MenuItem menuItem = new MenuItem("1", "Meal One", "description", "tomato, pickle", "3.95");
            MenuItem menuItemTwo = new MenuItem("2", "Meal Two", "description", "tomato, pickle", "3.85");
            repo.AddNewMenuItem(menuItem);
            repo.AddNewMenuItem(menuItemTwo);
            Assert.AreEqual(2, repo._menuRepo.Count);
            Console.WriteLine(repo._menuRepo.Count);
            repo.DeleteMenuItem("2");
            Assert.AreEqual(1, repo._menuRepo.Count);
            Console.WriteLine(repo._menuRepo.Count);
        }
    }
}
