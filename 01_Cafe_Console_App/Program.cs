using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console_App
{
    //5) Program that initializes an instance of "ProgramUI" and runs the "Run" method         DONE

    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();
        }
    }
    /*
     * Planning:
     * 
     *Prompt:
     * 
     * Komodo Cafe
Komodo cafe is getting a new menu. The manager wants to be able to create new menu items, delete menu items, and receive a list of all items on the cafe's menu. She needs a console app.

 

The Menu Items:
A meal number, so customers can say "I'll have the #5"
A meal name
A description
A list of ingredients,
A price
 

Your Task:
Create a Menu Class with properties, constructors, and fields.
Create a MenuRepository Class that has methods needed.
Create a Test Class for your repository methods. (You don't need to test your constructors or objects, just your methods)
Create a Program file that allows the cafe manager to add, delete, and see all items in the menu list.
 

Notes:
We don't need to be able to update items right now.
     * 
     * My Summary:
     * 
     * 1) Create a Menu Class with properties, constructors, and fields.        DONE
     *      properties:
     *      1. A meal number, so customers can say "I'll have the #5"
            2. A meal name
            3. A description
            4. A list of ingredients,
            5. A price
     *      constructors:
     *      1. empty ctor
     *      2. ctor with all props
     *      fields:
     *      1. unsure yet what this will be
     * 2) Create a MenuRepository Class that has methods needed.                DONE
     *      methods:
     *      1. create new menu items
     *      2. delete menu items with get by meal number helper method
     *      3. receive a list of all items on the cafe's menu
     * 3) ProgramUI Class that contains Run() method only                           DONE
     *      - a method that simply displays a console menu that links menu options to the different methods I will build
     *              - this method will be run by "ProgramUI"
     * 4) Create a Test Class for your repository methods.                              DONE
     *      (You don't need to test your constructors or objects, just your methods)
     * 5) Program that initializes an instance of "ProgramUI" and runs the "Run" method                DONE
    */
}
