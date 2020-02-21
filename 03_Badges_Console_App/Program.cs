using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI();
            ui.Run();
        }
    }
}

/*
 * My Summary:
 * 
 * 1 badge class                                        DONE
 *      constructors
 *      badge ID prop
 *      door names accesible prop (a list?)
 *      method to add door names to the list?
 *  
 *2  badge repo                                         DONE
 *     dictionary of badges
 *          key is badge id
 *          value is list of door names
 *     method to add a badge to the dict
 *          
 * 3 program                                            DONE
 *      instance of programui
 *      run the runmenu method
 *      
 * 4 programui                                          DONE
 *      runmenu method
 *              Hello Security Admin, What would you like to do?
    
                Add a badge
                Edit a badge.
                List all Badges
 *      create a new badge
 *              #1 Add a badge
                What is the number on the badge: 12345

                List a door that it needs access to: A5

                Any other doors(y/n)? y

                List a door that it needs access to: A7

                Any other doors(y/n)? n

                (Return to main menu.)
 *      update doors on a badge
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
 *      delete all doors from a badge
 *      show list of all badge numbers and door access
 *              #3 List all badges view
                Key	
                Badge #	Door Access
                12345	A7
                22345	A1, A4, B1, B2
                32345	A4, A5
 *              
 * 
 * 5 test methods
 *      
 * Challenge 3: Badges
Komodo Insurance
Komodo Insurance is fixing their badging system.

Here's what they need:
An app that maintains a dictionary of details about employee badge information. (Hint: A dictionary is a collection type in C#. You'll want to use that.)

Essentially, an badge will have a badge number that gives access to a specific list of doors. For instance, a developer might have access to Door A1 & A5. A claims agent might have access to B2 & B4.

Your task will be to create the following:
A badge class that has the following properties:
BadgeID
List of door names for access
A badge repository that will have methods that do the following:
Create a dictionary of badges.
The key for the dictionary will be the BadgeID.
The value for the dictionary will be the List of Door Names.
 

The Program will allow a security staff member to do the following:
create a new badge
update doors on an existing badge.
delete all doors from an existing badge.
show a list with all badge numbers and door access, like this:
Here are some views:
Menu

Hello Security Admin, What would you like to do?

Add a badge
Edit a badge.
List all Badges
#1 Add a badge
What is the number on the badge: 12345

List a door that it needs access to: A5

Any other doors(y/n)? y

List a door that it needs access to: A7

Any other doors(y/n)? n

(Return to main menu.)

#2 Update a badge
What is the badge number to update? 12345

12345 has access to doors A5 & A7.

What would you like to do?

Remove a door
Add a door
> 1

Which door would you like to remove? A5

Door removed.

12345 has access to door A7.

 

#3 List all badges view
Key	
Badge #	Door Access
12345	A7
22345	A1, A4, B1, B2
32345	A4, A5
 

Out of scope:
You do not need to consider tying an individual badge to a particular user. Just the Badge # will do.

Be sure to Unit Test your Repository methods.
 * */
