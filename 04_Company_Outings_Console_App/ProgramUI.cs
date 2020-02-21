using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Company_Outings_Console_App
{
    /*
     * ProgramUI
 *      Run Method                                              DONE
 *      CW and CR Wrapping methods
 *          Display all outings
 *          Add outings to repo
 *          Display cost reports (all one summary report)
     * */
    public class ProgramUI
    {
        OutingRepo _outingRepo = new OutingRepo();
        public bool isRunning = true;

        public void RunMenu()
        {
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Hello Welcome to Company Outing Management, What would you like to do?\n" + "\n" +
                    "1) Display All Outings\n" +
                    "2) Add An Outing\n" +
                    "3) Financial Summary Report\n" +
                    "4) Exit\n");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        DisplayOutings();
                        break;
                    case "2":
                        AddOuting();
                        break;
                    case "3":
                        DisplayFinReport();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void DisplayOutings()
        {

        }

        public void AddOuting()
        {

        }

        public void DisplayFinReport()
        {

        }

    }
}
