using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims__Console_App
{
    /*
     * 1. Claim Class                                                                       DONE
     *  - constructors                                                                      DONE
 *      - properties: ClaimID, ClaimType (Car, Home, Theft), Description, ClaimAmount,      DONE
 *      DateOfIncident, DateOfClaim, IsValid (based on incident/claim dates)                DONE
     * */
    public class Claim
    {
        public enum ClaimTypeOptions {Car=1,Home,Theft};

        public Claim() { }

        public Claim(string claimID, ClaimTypeOptions claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        public string ClaimID { get; set; }
        public ClaimTypeOptions ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan timeSpan = DateOfClaim - DateOfIncident;
                if(timeSpan.Days <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
