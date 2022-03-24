using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4ChallengeFour.ChallengeFourClasses
{
    public class C4OutingsRepo
    {
        protected readonly List<C4Outings> _outingDirectory = new List<C4Outings>();
        //Create
        public bool AddNewEvent(C4Outings outing)
        {
            int startingCount = _outingDirectory.Count();
            _outingDirectory.Add(outing);
            bool wasAdded = (_outingDirectory.Count() > startingCount);
            return wasAdded;
        }
        //Read
        public List<C4Outings> GetAllOutings()
        {
            return _outingDirectory;
        }
        public C4Outings GetOutingByType(EventType eventType)
        {
            return _outingDirectory.Where(o => o.EventType == eventType).SingleOrDefault();
        }
        //Update
        //Delete
        public bool RemoveEvent(C4Outings outing)
        {
            int startingCount = _outingDirectory.Count();
            _outingDirectory.Remove(outing);
            bool wasRemoved = (_outingDirectory.Count < startingCount);
            return wasRemoved;
        }
    }
}
