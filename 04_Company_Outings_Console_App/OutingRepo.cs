using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Company_Outings_Console_App
{
    /*
     * Repo
 *      List?                                                       DONE
 *      Methods
 *         Display list of all outings (the repo list)
 *         Add outings to the repo list                             DONE
 *         Calc and return total cost of all outings
 *         Calc and return cost by outing type
     * */
    public class OutingRepo
    {
        public List<Outing> _outingRepo = new List<Outing>();

        public bool AddOutingToRepo(Outing outing)
        {
            int dictionaryLength = _outingRepo.Count;
            _outingRepo.Add(outing);
            bool wasAdded = dictionaryLength + 1 == _outingRepo.Count;
            return wasAdded;
        }
        public List<Outing> GetAllOutings()
        {
            return _outingRepo;
        }
    }
}
