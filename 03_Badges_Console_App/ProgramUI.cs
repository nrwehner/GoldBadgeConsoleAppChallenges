using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console_App
{
    /*
     * 4 programui
 *      runmenu method                                                  DONE
 *              Hello Security Admin, What would you like to do?
    
                Add a badge
                Edit a badge.
                List all Badges
 *      create a new badge                                              DONE
 *              #1 Add a badge
                What is the number on the badge: 12345

                List a door that it needs access to: A5

                Any other doors(y/n)? y

                List a door that it needs access to: A7

                Any other doors(y/n)? n

                (Return to main menu.)
 *      update doors on a badge                                 DONE
 *              #2 Update a badge
                What is the badge number to update? 12345

                12345 has access to doors A5 & A7.

                What would you like to do?

                Remove a door
                Add a door
                > 1

                Which door would you like to remove? A5

                Door removed.

                12345 has access to door A7.
 *      delete all doors from a badge                                   DONE
 *      show list of all badge numbers and door access                  DONE
 *              #3 List all badges view
                Key	
                Badge #	Door Access
                12345	A7
                22345	A1, A4, B1, B2
                32345	A4, A5
     * */
    public class ProgramUI
    {
        BadgeRepo _badgeRepo = new BadgeRepo();
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
            Console.WriteLine("Hello Security Admin, What would you like to do?\n"+"\n"+
                "1) Add a badge\n"+
                "2) Edit a badge.\n"+
                "3) Delete a badge.\n" +
                "4) List all Badges\n" +
                "5) Exit\n");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        DeleteBadge();
                        break;
                    case "4":
                        ListAllBadges();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        /*
         * create a new badge
 *              #1 Add a badge
                What is the number on the badge: 12345

                List a door that it needs access to: A5

                Any other doors(y/n)? y

                List a door that it needs access to: A7

                Any other doors(y/n)? n

                (Return to main menu.)
         * */
        public void AddNewBadge()
        {
            Console.Clear();
            Badge badge = new Badge();
            bool addNewDoor = true;
            Console.WriteLine("You are adding a new badge.\n"+"\n");
            Console.WriteLine("What is the number on the badge?\n");
            string addBadgeID = Console.ReadLine();

            if (_badgeRepo.DoesBadgeIDExist(addBadgeID)==false)//BADGE EXIST IF
            {
            badge.BadgeID = addBadgeID;
            badge.DoorAccessList = new List<string>();

            while (addNewDoor)//ADD DOOR WHILE
            {
            Console.WriteLine($"\nList a door that badge {badge.BadgeID} needs access to:\n");
            badge.AddDoorToAccessList(Console.ReadLine());
            Console.WriteLine("\nAny other doors(y/n)?\n");
            string userYesNo = Console.ReadLine();

                if (userYesNo == "n")//WANT TO ADD DOOR IF
                {
                    addNewDoor = false;
                }

                else if (userYesNo == "y")//WANT TO ADD DOOR ELSE IF
                {

                }

                else//WANT TO ADD DOOR ELSE
                {
                    addNewDoor = false;
                    Console.WriteLine("\nYou did not provide y or n. Your badge will now be created.\n"+
                        "If you need to add more doors, use option 2 from the Main Menu\n" +
                        "Press any key to continue\n");
                    Console.ReadKey();
                }
            }
            _badgeRepo.AddBadgeToRepo(badge);
            Console.WriteLine($"\nBadge {badge.BadgeID} has been created with the accessible doors you provided. " +
                $"Press any key to continue.");
            Console.ReadKey();
            }

            else//BADGE EXIST ELSE
            {
                Console.WriteLine("That Badge ID already exists.  Please try again from the Main Menu\n");
                Console.ReadKey();
            }
        }

        /*
         *       update doors on a badge
 *              #2 Update a badge
                What is the badge number to update? 12345

                12345 has access to doors A5 & A7.

                What would you like to do?

                Remove a door
                Add a door
                > 1

                Which door would you like to remove? A5

                Door removed.

                12345 has access to door A7.
         * */
        public void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("You are making changes to a badge.\n" +
                "Would you like to continue? y/n\n");
            string userYesNo = Console.ReadLine();

            if (userYesNo == "y")//WANT TO BADGE CHANGE IF
            {
                Console.WriteLine("Please provide a badge ID that you would like to make changes to.");
                string badgeChanged = Console.ReadLine();

                if (_badgeRepo.DoesBadgeIDExist(badgeChanged))//BADGE EXIST IF
                {
                    Console.WriteLine($"What would you like to do to badge {badgeChanged}?\n" +
                        $"Add door access (enter 1)\n" +
                        $"Remove door access (enter 2)\n");
                    string userChoice = Console.ReadLine();

                    if (userChoice == "1")//USER CHANGE CHOICE IF
                    {
                        KeyValuePair<string,List<string>> badge = _badgeRepo.GetBadgeByBadgeID(badgeChanged);
                        string listString = string.Join(",", badge.Value.ToArray());
                        Console.WriteLine($"Badge {badge.Key} has access to doors {listString}.\n" +
                            $"Which door would you like to ADD access for?\n");
                        string doorAdd = Console.ReadLine();
                        _badgeRepo.GetBadgeByBadgeID(badgeChanged).Value.Add(doorAdd);
                        string listStringAfter = string.Join(",", badge.Value.ToArray());
                        Console.WriteLine($"Door {doorAdd} has been added to badge {badgeChanged}.\n" +
                            $"Badge {badgeChanged} now has access to doors {listStringAfter}.\n" +
                            $"Press any key to continue.");
                        Console.ReadKey();
                    }

                    else if (userChoice == "2")//USER CHANGE CHOICE ELSE IF
                    {
                        KeyValuePair<string, List<string>> badge = _badgeRepo.GetBadgeByBadgeID(badgeChanged);
                        string listString = string.Join(",", badge.Value.ToArray());
                        Console.WriteLine($"Badge {badge.Key} has access to doors {listString}.\n" +
                            $"Which door would you like to REMOVE access for?\n");
                        string doorRemove = Console.ReadLine();
                        bool doorRemoveExists = _badgeRepo.GetBadgeByBadgeID(badgeChanged).Value.Contains(doorRemove);

                        if (doorRemoveExists)//NEW DOOR EXISTS IF
                        {
                        bool removeSuccess = _badgeRepo.GetBadgeByBadgeID(badgeChanged).Value.Remove(doorRemove);

                            if (removeSuccess)//REMOVE SUCCESS IF
                            {
                                string listStringAfter = string.Join(",", badge.Value.ToArray());
                                Console.WriteLine($"Door {doorRemove} has been removed from badge {badgeChanged}.\n" +
                                    $"Badge {badgeChanged} now has access to doors {listStringAfter}.\n" +
                                    $"Press any key to continue.");
                                Console.ReadKey();
                            }

                            else//REMOVE SUCCESS ELSE
                            {
                                Console.WriteLine("Something went wrong. You will return to the Main Menu Now.\n" +
                                    "Press any key to continue\n");
                                Console.ReadLine();
                            }
                        }

                        else//NEW DOOR EXISTS ELSE
                        {
                            Console.WriteLine($"Badge {badgeChanged} already does not have access to door {doorRemove}.\n" +
                                $"You will now return to the Main Menu. Press any key to continue\n");
                            Console.ReadLine();
                        }
                    }

                    else//USER CHANGE CHOICE ELSE
                    {
                        Console.WriteLine("You did not enter 1 or 2. You will return to the Main Menu now where you can try option 2 again.\n" +
                            "Press any key to continue\n");
                        Console.ReadKey();
                    }
                }

                else//BADGE EXIST ELSE
                {
                    Console.WriteLine($"Badge {badgeChanged} does not exist. You will return to the Main Menu now.\n"+
                        "Press any key to continue");
                    Console.ReadKey();
                }
            }

            else if (userYesNo == "n")//WANT TO BADGE CHANGE ELSE IF
            {
                Console.WriteLine("You will now return to the Main Menu. Press any key to continue.");
                Console.ReadKey();
            }

            else//WANT TO BADGE CHANGE ELSE
            {
                Console.WriteLine("\nYou did not provide y or n. You will now be returned to the Main Menu.\n" +
                        "If you need to update a badge, try option 2 again from the Main Menu.\n" +
                        "Press any key to continue\n");
                Console.ReadKey();
            }
        }

        public void DeleteBadge()
        {
            Console.Clear();
            Console.WriteLine("You are removing a badge.\n" +
                "Would you like to continue? y/n\n");
            string userYesNo = Console.ReadLine();

            if (userYesNo == "y")//WANT TO REMOVE IF
            {
                Console.WriteLine("Please provide a badge ID that you would like to remove.");
                string badgeRemoveDoors = Console.ReadLine();
                KeyValuePair<string, List<string>> clearedBadge = _badgeRepo.GetBadgeByBadgeID(badgeRemoveDoors);
                bool success = _badgeRepo.DeleteBadge(badgeRemoveDoors);

                if (success)//DELETE SUCCESS IF
                {
                    Console.WriteLine($"You have removed badge {clearedBadge.Key}.\n" +
                        $"Press any key to continue.");
                    Console.ReadKey();
                }

                else//DELETE SUCCES ELSE
                {
                    Console.WriteLine("Something went wrong.  You will return to the Main Menu and can try again.\n" +
                        "Press any key to continue");
                    Console.ReadKey();
                }
            }

            else if (userYesNo == "n")//WANT TO REMOVE ELSE IF
            {
                Console.WriteLine("You will now return to the Main Menu. Press any key to continue.");
                Console.ReadKey();
            }

            else//WANT TO REMOVE ELSE
            {
                Console.WriteLine("\nYou did not provide y or n. You will now be returned to the Main Menu.\n" +
                        "If you need to remove a badge, try option 3 again from the Main Menu.\n" +
                        "Press any key to continue\n");
                Console.ReadKey();
            }
        }

        /*
         * show list of all badge numbers and door access
 *              #3 List all badges view
                Key	
                Badge #	Door Access
                12345	A7
                22345	A1, A4, B1, B2
                32345	A4, A5
         * */

        public void ListAllBadges()
        {
            Console.Clear();
            Dictionary<string,List<string>> directory = _badgeRepo.GetAllBadges();
            Console.WriteLine(String.Format("|{0,15}|{1,30}|","Badge #", "Door Access"));
            Console.WriteLine(String.Format("|{0,15}|{1,30}|","---------------", "------------------------------"));

            foreach (KeyValuePair<string,List<string>> badge in directory)
            {
                string listString = string.Join(",", badge.Value.ToArray());
                Console.WriteLine(String.Format("|{0,15}|{1,30}|",$"{badge.Key}", $"{listString}"));
                Console.WriteLine(String.Format("|{0,15}|{1,30}|","---------------", "------------------------------"));
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void SeedContent()
        {
            Badge badgeOne = new Badge("11111",new List<string>() {"1","1a","1b","2c"});
            _badgeRepo.AddBadgeToRepo(badgeOne);
            Badge badgeTwo = new Badge("11112", new List<string>() { "1", "1b", "1d", "2a" });
            _badgeRepo.AddBadgeToRepo(badgeTwo);
            Badge badgeThree = new Badge("11113", new List<string>() { "1", "1c", "1f", "2c","3","3a" });
            _badgeRepo.AddBadgeToRepo(badgeThree);
        }
    }
}
