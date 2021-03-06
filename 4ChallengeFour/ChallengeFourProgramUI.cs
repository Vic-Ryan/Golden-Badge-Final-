using _4ChallengeFour.ChallengeFourClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4ChallengeFour
{
    public class ChallengeFourProgramUI
    {
        private readonly C4OutingsRepo _repo = new C4OutingsRepo();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Company Outing Tracking \n" +
                    "1. See all outings \n" +
                    "2. See outing cost by type\n" +
                    "3. Add new outing \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllOutings();
                        break;
                    case "2":
                        SeeOutingCostByType();
                        break;
                    case "3":
                        AddNewOuting();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please input valid selection");
                        AnyKey();
                        break;
                }
            }
        }

        public void SeeAllOutings()
        {
            Console.Clear();
            decimal totalCost = 0;
            Console.WriteLine("Outing Type      Attendees     CostPerPerson     Date         TotalCost");
            List<C4Outings> listOfOutings = _repo.GetAllOutings();
            foreach (C4Outings outing in listOfOutings)
            {
                Console.WriteLine($"{outing.EventType,-20}{outing.Attendees,-14}${outing.CostPerPerson,-13}{outing.Date.ToShortDateString(),-15}${outing.TotalCost}");
                totalCost = totalCost + outing.TotalCost;
            }
            Console.WriteLine($"Total cost of outings: ${totalCost}");
            AnyKey();
        }

        public void SeeOutingCostByType()
        {
            Console.Clear();
            
            List<C4Outings> listOfOutings = _repo.GetAllOutings();
            Console.WriteLine("Enter the event you wish to see: \n" +
                "1. Amusement Parks \n" +
                "2. Golf \n" +
                "3. Concerts \n" +
                "4. Bowling");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    EventType amusementParks = EventType.AmusementPark;
                    OutingTypeCost(amusementParks, listOfOutings);
                    AnyKey();
                    break;
                case "2":
                    EventType golf = EventType.Golf;
                    OutingTypeCost(golf, listOfOutings);
                    AnyKey();
                    break;
                case "3":
                    EventType concerts = EventType.Concert;
                    OutingTypeCost(concerts, listOfOutings);
                    AnyKey();
                    break;
                case "4":
                    EventType bowling = EventType.Golf;
                    OutingTypeCost(bowling, listOfOutings);
                    AnyKey();
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.");
                    AnyKey();
                    break;
            }
        }

        public void AddNewOuting()
        {
            Console.Clear();
            C4Outings newOuting = new C4Outings();
            Console.WriteLine("Enter outing information");
            Console.WriteLine("Enter event type: \n" +
                "1. Amusement Park \n" +
                "2. Golf \n" +
                "3. Concert \n" +
                "4. Bowling");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    newOuting.EventType = EventType.AmusementPark;
                    break;
                case "2":
                    newOuting.EventType = EventType.Golf;
                    break;
                case "3":
                    newOuting.EventType = EventType.Concert;
                    break;
                case "4":
                    newOuting.EventType = EventType.Bowling;
                    break;
            }
            Console.Write("Enter amount of attendees: ");
            newOuting.Attendees = int.Parse(Console.ReadLine());
            Console.Write("Enter event date (MM/DD/YYYY): ");
            DateTime outingDate = DateTime.Parse(Console.ReadLine());
            newOuting.Date = outingDate;
            Console.Write("Enter cost per person: ");
            newOuting.CostPerPerson = decimal.Parse(Console.ReadLine());
            Console.Write($"Total cost for the outing: ${newOuting.TotalCost}. \n" +
                $"Proceed to add outing? Y/N: ");
            string addEvent = Console.ReadLine().ToLower();
            switch (addEvent)
            {
                case "y":
                case "yes":
                    if (_repo.AddNewEvent(newOuting))
                    {
                        Console.WriteLine("Added outing successfully.");
                        AnyKey();
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong trying to add outing.");
                        AnyKey();
                    }
                    break;
                case "n":
                case "no":
                    _repo.RemoveEvent(newOuting);
                    Console.WriteLine("Outing not added to list.");
                    AnyKey();
                    break;
            }
        }

        //Helper Methods
        public void AnyKey()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
        public void SeedContent()
        {
            C4Outings outingOne = new C4Outings(EventType.Concert, 23, new DateTime(2022, 3, 23), 30);
            C4Outings outingTwo = new C4Outings(EventType.Bowling, 18, new DateTime(2021, 8, 16), 17);
            C4Outings outingThree = new C4Outings(EventType.Golf, 10, new DateTime(2021, 7, 30), 20);
            C4Outings outingFour = new C4Outings(EventType.AmusementPark, 31, new DateTime(2021, 9, 26), 31);
            _repo.AddNewEvent(outingOne);
            _repo.AddNewEvent(outingTwo);
            _repo.AddNewEvent(outingThree);
            _repo.AddNewEvent(outingFour);
        }
        public void OutingTypeCost(EventType eventType, List<C4Outings> listOfOutings)
        {
            decimal totalCost = 0;
            foreach (C4Outings outing in listOfOutings)
            {
                if (outing.EventType == eventType)
                {
                    totalCost = totalCost + outing.TotalCost;
                }
            }
            Console.WriteLine($"{eventType} Total Cost is ${totalCost}");
        }
    }
}
