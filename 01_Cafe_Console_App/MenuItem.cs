using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console_App
{
    /*
     * 1) Create a Menu Class with properties, constructors, and fields.        DONE
     * properties:                                                              DONE
     *      1. A meal number, so customers can say "I'll have the #5"           DONE
            2. A meal name                                                      DONE
            3. A description                                                    DONE
            4. A list of ingredients,                                           DONE
            5. A price                                                          DONE
     * constructors:                                                            DONE
     *      1. empty ctor                                                       DONE
     *      2. ctor with all props                                              DONE
     * fields:                                                                  DONE
     *      1. unsure yet what this will be - maybe the pass-throughs in ctor?  DONE
     *      */
    public class MenuItem
    {
        public MenuItem(){}
        public MenuItem(string mealNumber, string mealName, string description, string ingredientList, string price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            IngredientList = ingredientList;
            Price = price;
        }

        public string MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }

        //public List<string> IngredientList { get; set; }
        public string IngredientList { get; set; }
        public string Price { get; set; }

        /*public void AddIngredient(string ingredient)
        {
            IngredientList.Add(ingredient);
        }*/
    }
}
