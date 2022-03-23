using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.C2Classes
{
    public enum ClaimType { Car, Home, Theft}
    public class C2Claims
    {
        public C2Claims() { }
        public C2Claims(int claimID, ClaimType claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }

        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { 
            get
            {
                var diffOfDates = DateOfClaim.Subtract(DateOfIncident);
                var daysSince = diffOfDates.Days;
                if (daysSince <= 30)
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
