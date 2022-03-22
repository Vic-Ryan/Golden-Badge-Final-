using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.ChallengeThreeClasses
{
    public class C3BadgesRepo
    {
        protected readonly List<C3Badges> _badgeDirectory = new List<C3Badges>();
        protected readonly Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        //Create
        public bool AddNewBadge(C3Badges badge)
        {
            int startingCouint = _badgeDictionary.Count();
            _badgeDictionary.Add(badge.BadgeID, badge.DoorAccess);
            bool wasAdded = (_badgeDictionary.Count > startingCouint);
            return wasAdded;
        }
        //Read
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeDictionary;
        }
        public C3Badges GetBadgeByID(int badgeNumber)
        {
            return _badgeDirectory.Where(b => b.BadgeID == badgeNumber).SingleOrDefault();
        }
        //Update
        public bool UpdateDoorInformation(int badgeId, string doorAccess) 
        {
            if (_badgeDictionary.ContainsKey(badgeId))
            {
                _badgeDictionary[badgeId].Add(doorAccess);
                return true;
            }
            else
                return false;
        } 
        //Delete
        public bool RemoveBadge(int badgeId)
        {
            int startingCount = _badgeDictionary.Count();
            _badgeDictionary.Remove(badgeId);
            bool wasRemoved = (_badgeDictionary.Count < startingCount);
            return wasRemoved;
        }
        public bool RemoveDoorInformation(int badgeId, string doorAccess)
        {
            if (_badgeDictionary.ContainsKey(badgeId))
            {
                _badgeDictionary[badgeId].Remove(doorAccess);
                return true;
            }
            else
                return false;
        }
    }
}
