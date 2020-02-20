using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console_App
{
    /*
     * 1 badge class                                DONE
 *      constructors                                DONE
 *      badge ID prop                               DONE
 *      door names accesible prop (a list?)         DONE
 *      method to add door names to the list?       DONE
     * */
    public class Badge
    {
        public Badge() { }
        public Badge(string badgeID,List<string> doorAccessList)
        {
            BadgeID = badgeID;
            DoorAccessList = doorAccessList;
        }

        public string BadgeID { get; set; }
        public List<string> DoorAccessList { get; set; }

        public void AddDoorToAccessList(string door)
        {
            DoorAccessList.Add(door);
        }
    }
}
