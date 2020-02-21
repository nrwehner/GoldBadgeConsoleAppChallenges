using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _02_Claims__Console_App.Claim;

namespace _02_Claims__Console_App
{
    /*
     * 3. ProgramUI - menu method:                                                      DONE
 *      - show claims agent a menu
 *      Choose a menu item:
            1. See all claims
            2. Take care of next claim
            3. Enter a new claim

        1 see all claims - in provided format                                               DONE
 *              ClaimID Type    Description Amount  DateOfAccident DateOfClaim IsValid
                    1	Car Car accident on 465.	$400.00	4/25/18	4/27/18	true
                    2	Home House fire in kitchen.  $4000.00	4/11/18	4/12/18	true
                    3	Theft Stolen pancakes.    $4.00	4/27/18	6/01/18	false
 *          2 take care of next - show next in queue only                                   DONE
 *                  Here are the details for the next claim to be handled:
                    ClaimID: 1
                    Type: Car
                    Description: Car Accident on 464.
                    Amount: $400.00
                    DateOfAccident: 4/25/18
                    DateOfClaim: 4/27/18
                    IsValid: True
                Do you want to deal with this claim now(y/n)? y
                When the agent presses 'y', the claim will be pulled off the top of the queue. If the agent presses 'n', it will go back to the main menu.
 *          3 enter a new - prompt user to enter values                                     DONE - make error checking better?
 *                  Enter the claim id: 4
                    Enter the claim type: Car
                    Enter a claim description: Wreck on I-70.
                    Amount of Damage: $2000.00
                    Date Of Accident: 4/27/18
                    Date of Claim: 4/28/18
                    This claim is valid.
     * */
    public class ProgramUI
    {
        ClaimRepo repo = new ClaimRepo();
        public bool isRunning = true;

        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        public void RunMenu()
        {
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("Welcome to Claims Management.\n" +
                    "\n" +
                    "Choose a menu item:\n" +
                    "\n" +
                    "1) See All Claims\n" +
                    "2) Take Care Of Next Claim\n" +
                    "3) Enter a New Claim\n" +
                    "4) Exit\n");

                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        public void EnterNewClaim()
        {
            Console.Clear();
            Claim claim = new Claim();
            Console.WriteLine("Enter The Claim ID:\n");
            claim.ClaimID = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter The Claim Type:\n" +
                "Enter 1 for Car\n" +
                "Enter 2 for Home\n" +
                "Enter 3 for Theft\n");
            string userClaimType = Console.ReadLine();

            if(userClaimType != "1" && userClaimType != "2" && userClaimType != "3")//CLAIMTYPE ENTRY IF
            {
                Console.WriteLine("You did not provide 1, 2, or 3.  You will return to the Main Menu now.\n" +
                    "Press any key to continue");
                Console.ReadLine();
            }

            else//CLAIMTYPE ENTRY ELSE
            {
            int claimTypeID = int.Parse(userClaimType);
            claim.ClaimType = (ClaimTypeOptions)claimTypeID;
            //public enum ClaimTypeOptions { Car = 1, Home, Theft };
            Console.Clear();
            Console.WriteLine("Enter a Claim Description:");
            claim.Description = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Amount of Damage (#s only):\n");
                Console.Write("$");
            string damageAmount = Console.ReadLine();
            claim.ClaimAmount = Convert.ToDouble(damageAmount);
            Console.Clear();
            Console.WriteLine("Date of Accident:");
            Console.Write("Enter a month (1 - 12): ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day (1 - 31 depending on month): ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter a year (ie 2020): ");
            int year = int.Parse(Console.ReadLine());
            DateTime userIncidentDate = new DateTime(year, month, day);

           if(userIncidentDate < new DateTime(1900,1,1) || userIncidentDate > DateTime.Now)//INCIDENTDATE ENTRY IF
                {
                    Console.WriteLine($"{userIncidentDate.ToShortDateString()} is not a valid Incident Date. You will return to the Main Menu now to start over.\n" +
                        "Press any key to continue.");
                    Console.ReadKey();
                }

           else //INCIDENTDATE ENTRY ELSE
                { 
                claim.DateOfIncident = userIncidentDate;
            Console.Clear();
            Console.WriteLine("Date of Claim:");
            Console.Write("Enter a month (1 - 12): ");
            int monthClaim = int.Parse(Console.ReadLine());
            Console.Write("Enter a day (1 - 31 depending on month): ");
            int dayClaim = int.Parse(Console.ReadLine());
            Console.Write("Enter a year (ie 2020): ");
            int yearClaim = int.Parse(Console.ReadLine());
            DateTime userClaimDate = new DateTime(yearClaim, monthClaim, dayClaim);
           if(userClaimDate < userIncidentDate || userClaimDate > DateTime.Now)//CLAIMDATE ENTRY IF
            {
                        Console.WriteLine($"{userClaimDate.ToShortDateString()} is not a valid Claim Date for an Incident Date of {userIncidentDate.ToShortDateString()}.\n" +
                            $"You will return to the Main Menu now to start over.\n" +
                        "Press any key to continue.");
                        Console.ReadKey();
             }

           else//CLAIMDATE ENTRY ELSE
            {
                claim.DateOfClaim = userClaimDate;
            repo.AddClaimToRepo(claim);
            Console.WriteLine((claim.IsValid) ? "The Claim is Valid" : "The Claim is Not Valid");
            Console.WriteLine("Your item has been added to the menu, press any key to continue.");
            Console.ReadKey();
             }
            }
           }
        }

        /*
         *  Do you want to deal with this claim now(y/n)? y
                When the agent presses 'y', the claim will be pulled off the top of the queue. If the agent presses 'n', it will go back to the main menu.
         * */
        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            bool areClaims = repo.DisplayNextClaim();
            if (areClaims)//CLAIMS EXIST IF
            {
            Console.WriteLine("\nDo you want to deal with this claim now (y/n)?\n");
            string userChoice = Console.ReadLine();

            if (userChoice == "n")//DEAL WITH CLAIM IF
            {
                Claim nextClaim = repo._claimRepo.Peek();
                Console.WriteLine($"Claim {nextClaim.ClaimID} will remain next in queue.  Press any key to continue.");
                Console.ReadKey();
            }

            else if (userChoice == "y")//DEAL WITH CLAIM ELSE IF
            {
                Claim nextClaim = repo._claimRepo.Peek();
                repo._claimRepo.Dequeue();
                bool areThereClaims = (repo._claimRepo.Count != 0) ? true : false;

                    if (areThereClaims)//NEW CLAIMS EXIST IF
                    {
                Claim newNextClaim = repo._claimRepo.Peek();
                Console.WriteLine($"Claim {nextClaim.ClaimID} has been removed from queue.  The next claim is now claim {newNextClaim.ClaimID}.\n" +
                    $"Press any key to continue.");
                Console.ReadKey();
                    }

                    else//NEW CLAIMS EXIST ELSE
                    {
                Console.WriteLine($"Claim {nextClaim.ClaimID} has been removed from queue.  There are now no claims in the queue.\n" +
                    $"Press any key to continue.");
                Console.ReadKey();
                    }
                }

            else//DEAL WITH CLAIM ELSE
            {
                Console.WriteLine("\nYou did not provide y or n. You will now be returned to the Main Menu.\n" +
                    "Press any key to continue\n");
                Console.ReadKey();
            }
            }

            else//CLAIMS EXIST ELSE
            {
                Console.WriteLine("Press any key to continue\n");
                Console.ReadKey();
            }
        }
        public void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> directory = repo.GetAllClaims();
            Console.WriteLine(String.Format("|{0,15}|{1,10}|{2,30}|{3,15}|{4,16}|{5,16}|{6,10}|", 
                "Claim ID", "Claim Type", "Description", "Amount","Date Of Incident","Date Of Claim","Is Valid"));
            Console.WriteLine(String.Format("|{0,15}|{1,10}|{2,30}|{3,15}|{4,16}|{5,16}|{6,10}|", 
                "---------------", "----------", "------------------------------", "---------------", "----------------", "----------------", "----------"));
            foreach (Claim claim in directory)
            {
                Console.WriteLine(String.Format("|{0,15}|{1,10}|{2,30}|{3,15}|{4,16}|{5,16}|{6,10}|", 
                    $"{claim.ClaimID}", $"{claim.ClaimType}", $"{claim.Description}", $"{claim.ClaimAmount}", $"{claim.DateOfIncident.ToShortDateString()}", $"{claim.DateOfClaim.ToShortDateString()}", $"{claim.IsValid}"));
                Console.WriteLine(String.Format("|{0,15}|{1,10}|{2,30}|{3,15}|{4,16}|{5,16}|{6,10}|",
                    "---------------", "----------", "------------------------------", "---------------", "----------------", "----------------", "----------"));
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /*
         *  ClaimID Type    Description Amount  DateOfAccident DateOfClaim IsValid
                1	Car Car accident on 465.	$400.00	4/25/18	4/27/18	true
                2	Home House fire in kitchen.  $4000.00	4/11/18	4/12/18	true
                3	Theft Stolen pancakes.    $4.00	4/27/18	6/01/18	false
         * */

        public void SeedContent()
        {
            Claim claimOne = new Claim("123",ClaimTypeOptions.Car,"I can't believe this happened!",2000,new DateTime(2020,1,1),new DateTime(2020,1,10));
            repo.AddClaimToRepo(claimOne);
            Claim claimTwo = new Claim("124", ClaimTypeOptions.Theft, "People really steal stuff?!", 2500, new DateTime(2019, 12, 20), new DateTime(2019, 12, 22));
            repo.AddClaimToRepo(claimTwo);
            Claim claimThree = new Claim("125", ClaimTypeOptions.Home, "Why did I ever buy a home!?", 15000, new DateTime(2019, 10,22), new DateTime(2019, 11, 24));
            repo.AddClaimToRepo(claimThree);
        }

    }
}


