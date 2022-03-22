using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.C2Classes
{
    public class C2ClaimsRepo
    {
        protected readonly List<C2Claims> _claimsDirectory = new List<C2Claims>();
        //Create
        public bool AddNewClaim(C2Claims claim)
        {
            int startingCount = _claimsDirectory.Count();
            _claimsDirectory.Add(claim);
            bool wasAdded = (_claimsDirectory.Count() > startingCount);
            return wasAdded;
        }
        //Read
        public List<C2Claims> GetAllClaims()
        {
            return _claimsDirectory;
        }
        
        public C2Claims GetFirstClaim()
        {
            C2Claims firstClaim = _claimsDirectory[0];
            return firstClaim;
        } 
        //Update... if needed?
        //Delete
        public bool RemoveClaim(C2Claims claim)
        {
            bool wasRemoved = _claimsDirectory.Remove(claim);
            return wasRemoved;
        }
    }
}
