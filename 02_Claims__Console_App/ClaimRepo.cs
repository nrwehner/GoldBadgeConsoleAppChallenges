using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims__Console_App
{
    /*
     * 2. Repo
 *      - repo list to hold claims - use a queue?                                           DONE
 *      - methods:
 *          1 see all claims - in provided format
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
    public class ClaimRepo
    {
        public Queue<Claim> _claimRepo = new Queue<Claim>();

        public Queue<Claim> GetAllClaims()
        {
            return _claimRepo;
        }
        public void DeQueueNextClaim()
        {
            _claimRepo.Dequeue();
        }
        public bool AddClaimToRepo(Claim claim)
        {
            int claimRepoLength = _claimRepo.Count();
            _claimRepo.Enqueue(claim);
            bool wasAdded = claimRepoLength + 1 == _claimRepo.Count();
            return wasAdded;
        }
    }
}
