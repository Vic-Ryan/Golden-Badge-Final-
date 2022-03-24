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
            //SeedContent();
            //RunMenu();
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
                    "3. See total outing costs \n" +
                    "4. Add new outing \n" +
                    "5. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //SeeAllOutings();
                        break;
                    case "2":
                        //SeeOutingCostByType();
                        break;
                    case "3":
                        //SeeTotalCost();
                        break;
                    case "4":
                        //AddNewOuting();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please input valid selection");
                        AnyKey();
                        break;
                }
            }
        }

        //Helper Methods
        public void AnyKey()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }
}
