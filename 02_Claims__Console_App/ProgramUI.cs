using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _02_Claims__Console_App.Claim;

namespace _02_Claims__Console_App
{
    /*
     * 3. ProgramUI - menu method:
 *      - show claims agent a menu
 *      Choose a menu item:
            1. See all claims
            2. Take care of next claim
            3. Enter a new claim

        1 see all claims - in provided format
 *              ClaimID Type    Description Amount  DateOfAccident DateOfClaim IsValid
                    1	Car Car accident on 465.	$400.00	4/25/18	4/27/18	true
                    2	Home House fire in kitchen.  $4000.00	4/11/18	4/12/18	true
                    3	Theft Stolen pancakes.    $4.00	4/27/18	6/01/18	false
 *          2 take care of next - show next in queue only
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
 *          3 enter a new - prompt user to enter values
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
                        //TakeCareOfNextClaim();
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
            int claimTypeID = int.Parse(userClaimType);
            claim.ClaimType = (ClaimTypeOptions)claimTypeID;
            //public enum ClaimTypeOptions { Car = 1, Home, Theft };
            Console.Clear();
            Console.WriteLine("Enter a Claim Description:");
            claim.Description = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Amount of Damage:\n" +
                "$");
            string damageAmount = Console.ReadLine();
            claim.ClaimAmount = Convert.ToDouble(damageAmount);
            Console.Clear();
            Console.WriteLine("Date of Accident:");
            Console.Write("Enter a month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter a year: ");
            int year = int.Parse(Console.ReadLine());
            claim.DateOfIncident = new DateTime(year, month, day);
            Console.Clear();
            Console.WriteLine("Date of Claim:");
            Console.Write("Enter a month: ");
            int monthClaim = int.Parse(Console.ReadLine());
            Console.Write("Enter a day: ");
            int dayClaim = int.Parse(Console.ReadLine());
            Console.Write("Enter a year: ");
            int yearClaim = int.Parse(Console.ReadLine());
            claim.DateOfClaim = new DateTime(yearClaim, monthClaim, dayClaim);
            repo.AddClaimToRepo(claim);
            Console.WriteLine((claim.IsValid) ? "The Claim is Valid" : "The Claim is Not Valid");
            Console.WriteLine("Your item has been added to the menu, press any key to continue.");
            Console.ReadKey();
        }
        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here are the details for the next claim to be handled:");
            repo._claimRepo.Peek();
        }
        public void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> directory = repo.GetAllClaims();

            Console.WriteLine("ClaimID Type    Description Amount  DateOfAccident DateOfClaim IsValid\n");
            foreach (Claim claim in directory)
            {
                Console.WriteLine($"{claim.ClaimID}   {claim.ClaimType}    {claim.Description}    ${claim.ClaimAmount}    {claim.DateOfIncident}    {claim.DateOfClaim}    {claim.IsValid}\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        /*
         *  ClaimID Type    Description Amount  DateOfAccident DateOfClaim IsValid
                1	Car Car accident on 465.	$400.00	4/25/18	4/27/18	true
                2	Home House fire in kitchen.  $4000.00	4/11/18	4/12/18	true
                3	Theft Stolen pancakes.    $4.00	4/27/18	6/01/18	false
         * */
    }
}


