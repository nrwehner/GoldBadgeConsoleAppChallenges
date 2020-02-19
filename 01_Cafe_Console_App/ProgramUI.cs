using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console_App
{
    /*
     * 3) ProgramUI Class that contains Run() method only                                                                   DONE
     *      - a method that simply displays a console menu that links menu options to the different methods I will build    DONE
     *              - this method will be run by "Program"
    */

    class ProgramUI
    {
        Repo repo = new Repo();
        public bool isRunning = true;
        public void Run()
        {
            while (isRunning)
            {
            Console.Clear();

            Console.WriteLine("Welcome to Menu Management.\n"+
                "\n"+
                "Select an option below (enter 1 through 4)\n"+
                "\n"+
                "1) Create a New Menu Item\n"+
                "2) Delete a Menu Item\n"+
                "3) Show All Menu Items\n"+
                "4) Exit\n");

            string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        CreateNewMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ShowAllMenuItems();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void CreateNewMenuItem()
        {
            Console.Clear();
            MenuItem item = new MenuItem();
            Console.WriteLine("Please provide a Meal Number.");
            item.MealNumber = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please provide a Meal Name.");
            item.MealName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please provide a Meal Description.");
            item.Description = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please provide the ingredients.");
            item.IngredientList = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please provide a Meal Price.");
            item.Price = Console.ReadLine();
            Console.Clear();
            repo.AddNewMenuItem(item);
            Console.WriteLine("Your item has been added to the menu, press any key to continue.");
            Console.ReadKey();
        }
        public void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Please provide a Meal Number of the meal you would like to remove.");
            string deleteMeal = Console.ReadLine();
            if (repo.GetMenuItemByMealNumber(deleteMeal) != null)
            {
                string storedDeleteValues = $"{repo.GetMenuItemByMealNumber(deleteMeal).MealNumber}: " +
                    $"{repo.GetMenuItemByMealNumber(deleteMeal).MealName}, " +
                    $"{repo.GetMenuItemByMealNumber(deleteMeal).Description}, " +
                    $"{repo.GetMenuItemByMealNumber(deleteMeal).IngredientList}, " +
                    $"{repo.GetMenuItemByMealNumber(deleteMeal).Price}. ";
            bool isDeleted = repo.DeleteMenuItem(deleteMeal);
                if (isDeleted)
                {
                    Console.WriteLine($"You deleted the following Menu Item:\n" +
                        $"{storedDeleteValues}\n Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Something went wrong.  Press any key to continue.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("That Menu Item does not exist.  Press any key to continue.");
                Console.ReadKey();
            }
        }
        public void ShowAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> directory = repo.GetAllMenuItems();

            foreach(MenuItem item in directory)
            {
            Console.WriteLine($"Meal Number: {item.MealNumber}\n"+
                $"Meal Name: {item.MealName}\n"+
                $"Description: {item.Description}\n" +
                $"Ingredients: {item.IngredientList}\n"+
                $"Price: {item.Price}\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
