using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console_App
{
    /*
     * 2) Create a MenuRepository Class that has methods needed.        DONE
     *      methods:
     *      1. create new menu items                                    DONE
     *      2. delete menu items with get my mealnumber helper          DONE
     *      3. receive a list of all items on the cafe's menu           DONE
     * */
    public class Repo
    {
        public List<MenuItem> _menuRepo = new List<MenuItem>();

        public bool AddNewMenuItem(MenuItem item)
        {
            int menuRepoLength = _menuRepo.Count();
            _menuRepo.Add(item);
            bool wasAdded = menuRepoLength + 1 == _menuRepo.Count();
            return wasAdded;
        }
        public List<MenuItem> GetAllMenuItems()
        {
            return _menuRepo;
        }
        public MenuItem GetMenuItemByMealNumber(string mealNumber)
        {
            foreach (MenuItem item in _menuRepo)
            {
                if (item.MealNumber == mealNumber)
                {
                    return item;
                }
            }
            return null;
        }
        public bool DeleteMenuItem(string mealNumber)
        {
            MenuItem foundMenuItem = GetMenuItemByMealNumber(mealNumber);
            bool deletedResult = _menuRepo.Remove(foundMenuItem);
            return deletedResult;
        }
    }
}
