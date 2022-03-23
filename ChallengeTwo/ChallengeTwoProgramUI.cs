using ChallengeTwo.C2Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo
{

    public class ChallengeTwoProgramUI
    {
        private readonly C2ClaimsRepo _repo = new C2ClaimsRepo();
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
                Console.WriteLine("Welcome, please select a menu option: \n" +
                    "1. See all claims\n" +
                    "2. Proceed to the next claim \n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        GoToFirstClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        AnyKey();
                        break;
                }
            }
        }

        public void SeeAllClaims()
        {
            Console.Clear();
            Console.WriteLine("Claim ID     Type       Description        Amount     DateOfAccident   DateOfClaim     IsValid");
            List<C2Claims> listOfClaims = _repo.GetAllClaims();
            foreach (C2Claims claim in listOfClaims)
            {
                Console.WriteLine($"{claim.ClaimID,-13}{claim.ClaimType,-10}{claim.Description,-20}${claim.ClaimAmount,-10 }{claim.DateOfIncident.ToShortDateString(),-15} {claim.DateOfClaim.ToShortDateString(),-20}{claim.IsValid}");
                Console.WriteLine();
            }
            AnyKey();
        }

        public void GoToFirstClaim()
        {
            Console.Clear();
            C2Claims firstClaim = _repo.GetFirstClaim();
            Console.WriteLine($"Details for the next claim to be handled: \n" +
                $"Claim ID: {firstClaim.ClaimID}\n" +
                $"Type: {firstClaim.ClaimType}\n" +
                $"Amount: ${firstClaim.ClaimAmount}\n" +
                $"Date Of Accident: {firstClaim.DateOfIncident.ToShortDateString()}\n" +
                $"Date of Claim: {firstClaim.DateOfClaim.ToShortDateString()}\n" +
                $"Is Valid: {firstClaim.IsValid}");
            Console.Write("Do you want to handle this claim now? Y/N: ");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "y":
                case "yes":
                    _repo.RemoveClaim(firstClaim);
                    Console.WriteLine("Claim taken, thank you.");
                    AnyKey();
                    break;
                case "n":
                case "no":
                    Console.WriteLine("Claim not taken.");
                    AnyKey();
                    break;
                default:
                    Console.WriteLine("Invalid input, please use yes or no.");
                    AnyKey();
                    break;
            }
        }

        public void EnterNewClaim()
        {
            C2Claims newClaims = new C2Claims();
            Console.Clear();
            Console.WriteLine("Enter new Claim information");
            Console.Write("Claim ID: ");
            int newId = int.Parse(Console.ReadLine());
            newClaims.ClaimID = newId;
            Console.Write("Claims: 1. Car  2. Home  3. Theft \n" +
                "Enter Claim: ");
            string claimType = Console.ReadLine().ToLower();
            switch (claimType)
            {
                case "car":
                case "1":
                    newClaims.ClaimType = ClaimType.Car;
                    break;
                case "home":
                case "2":
                    newClaims.ClaimType = ClaimType.Home;
                    break;
                case "theft":
                case "3":
                    newClaims.ClaimType = ClaimType.Theft;
                    break;
            }
            Console.Write("Enter Description: ");
            newClaims.Description = Console.ReadLine();
            Console.Write("Enter Amount: ");
            decimal claimAmount = decimal.Parse(Console.ReadLine());
            newClaims.ClaimAmount = claimAmount;
            Console.Write("Incident Date (MM/DD/YYYY): ");
            DateTime incidentDate = DateTime.Parse(Console.ReadLine());
            newClaims.DateOfIncident = incidentDate;
            Console.Write("Claim Date (MM/DD/YYYY): ");
            DateTime claimDate = DateTime.Parse(Console.ReadLine());
            newClaims.DateOfClaim = claimDate;
            Console.WriteLine($"Is Valid: {newClaims.IsValid}");
            if (_repo.AddNewClaim(newClaims))
            {
                Console.WriteLine("Claim added succesfully.");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again.");
            }
            AnyKey();
        }

        //Helper Methods
        public void AnyKey()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }

        public void SeedContent()
        {
            C2Claims claimOne = new C2Claims(1, ClaimType.Home, "Fire in the garage", 2500.00m, new DateTime(2022, 2, 23), new DateTime(2022, 2, 26));
            C2Claims claimTwo = new C2Claims(2, ClaimType.Theft, "Stolen Computer", 1200.00m, new DateTime(2022, 3, 2), new DateTime(2022, 3, 13));
            C2Claims claimThree = new C2Claims(3, ClaimType.Car, "Accident on 61", 345.00m, new DateTime(2022, 2, 13), new DateTime(2022, 3, 20));

            _repo.AddNewClaim(claimOne);
            _repo.AddNewClaim(claimTwo);
            _repo.AddNewClaim(claimThree);
        }
    }
}
