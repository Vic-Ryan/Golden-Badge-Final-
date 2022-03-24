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
                        //SeeOutingCostByType();
                        break;
                    case "3":
                        //AddNewOuting();
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

        }
        public void SeeTotalCost()
        {

        }

        public void AddNewOuting()
        {

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
            _repo.AddNewEvent(outingOne);
            _repo.AddNewEvent(outingTwo);
            _repo.AddNewEvent(outingThree);
        }
    }
}
