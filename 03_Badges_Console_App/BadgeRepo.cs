using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console_App
{
    /*
     * *2  badge repo
 *     dictionary of badges                 DONE
 *          key is badge id                 DONE
 *          value is list of door names     DONE
 *      method to add a badge to the dict   DONE
     * */
    public class BadgeRepo
    {
        public Dictionary<string, List<string>> _badgeRepo = new Dictionary<string, List<string>>();

        public bool AddBadgeToRepo(Badge badge)
        {
            int dictionaryLength = _badgeRepo.Count;
            _badgeRepo.Add(badge.BadgeID,badge.DoorAccessList);
            bool wasAdded = dictionaryLength + 1 == _badgeRepo.Count;
            return wasAdded;
        }
        public bool DoesBadgeIDExist(string badgeID)
        {
            return _badgeRepo.ContainsKey(badgeID);
        }
        public Dictionary<string,List<string>> GetAllBadges()
        {
            return _badgeRepo;
        }
        public KeyValuePair<string,List<string>> GetBadgeByBadgeID(string badgeID)
        {
            foreach (KeyValuePair<string,List<string>> badge in _badgeRepo)
            {
                if (badge.Key == badgeID)
                {
                    return badge;
                }
            }
            List<string> list = new List<string>();
            KeyValuePair<string, List<string>> kVPair = new KeyValuePair<string, List<string>>("DNE",list);
            return kVPair;
        }
        public bool DeleteBadge(string badgeID)
        {
            KeyValuePair<string,List<string>> foundBadge = GetBadgeByBadgeID(badgeID);
            bool deletedResult = _badgeRepo.Remove(foundBadge.Key);
            return deletedResult;
        }
    }
}
