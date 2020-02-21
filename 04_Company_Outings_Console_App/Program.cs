using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Company_Outings_Console_App
{
    //Program - per usual, the run method       DONE

    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ui.RunMenu();
        }
    }
}
/*
 * My Summary:
 * 
 * Outing Class                                                 DONE
 *      Type Prop
 *      Attendance Prop
 *      Date Prop
 *      CostPerPerson Prop - Calc only based on TotalCost
 *      TotalCost Prop
 *      
 * Repo
 *      List?
 *      Methods
 *         Display list of all outings (the repo list)
 *         Add outings to the repo list
 *         Calc and return total cost of all outings
 *         Calc and return cost by outing type
 *      
 * ProgramUI
 *      Run Method
 *      CW and CR Wrapping methods
 *          Display all outings
 *          Add outings to repo
 *          Display cost reports (all one summary report)
 * 
 * Program - per usual, the run method                      DONE
 * 
 * Unit Tests - repo methods
 * 
 * Komodo Outings
Komodo accountants need a list of all outings, the cost of all outings combined, and the cost of all types of outings combined.

Here are the parts of an outing:
Event Type:   Golf, Bowling, Amusement Park, Concert
Number of people that attended
Date
Total cost per person for the event
Total cost for the event
 

Here's what they'd like:
Display a list of all outings.
Add individual outings to a list(don't need to worry about delete yet)
Calculations:
They'd like to see a display for the combined cost for all outings.
They'd like to see a display of outing costs by type.
For example, all bowling outings for the year were $2000.00. All Concert outings cost $5000.00.
 

Be sure to Unit Test your Repository methods.
 * */
