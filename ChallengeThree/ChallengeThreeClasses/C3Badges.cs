using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.ChallengeThreeClasses
{
    public class C3Badges
    {
        public C3Badges() { }
        public C3Badges(int badgeId, List<string> doorAccess)
        {
            BadgeID = badgeId;
            DoorAccess = doorAccess;
        }
        public int BadgeID { get; set; }
        public List<string> DoorAccess { get; set; }
    }
}
