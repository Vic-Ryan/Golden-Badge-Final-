using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4ChallengeFour.ChallengeFourClasses
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert }
    public class C4Outings
    {
        C4Outings() { }
        C4Outings(EventType eventType, int attendees, DateTime date, decimal costPerPerson)
        {
            EventType = eventType;
            Attendees = attendees;
            Date = date;
            CostPerPerson = costPerPerson;
        }
        public EventType EventType { get; set; }
        public int Attendees { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostOfEvent
        {
            get
            {
                decimal cost = Attendees * CostPerPerson;
                return cost;
            }
        }
    }
}
