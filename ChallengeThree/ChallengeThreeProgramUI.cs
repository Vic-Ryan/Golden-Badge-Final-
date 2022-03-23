using ChallengeThree.ChallengeThreeClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree
{
    public class ChallengeThreeProgramUI
    {
        private readonly C3BadgesRepo _repo = new C3BadgesRepo();

        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        public void RunMenu()
        {
            bool ContinueToRun = true;
            while (ContinueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello, Security Admin, please select an option: \n" +
                    "1. List all badges \n" +
                    "2. Add new badge \n" +
                    "3. Update badge access \n" +
                    "4. Delete badge \n" +
                    "5. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ViewAllBadges();
                        break;
                    case "2":
                        AddNewBadge();
                        break;
                    case "3":
                        UpdateDoorAcess();
                        break;
                    case "4":
                        DeleteExistingBadge();
                        break;
                    case "5":
                        ContinueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        AnyKey();
                        break;
                }

            }
        }
        public void ViewAllBadges()
        {
            Console.Clear();
            Console.WriteLine("Badge #     Door Access ");
            Dictionary<int, List<string>> listOfBadges = _repo.GetAllBadges();
            foreach (KeyValuePair<int, List<string>> badge in listOfBadges)
            {
                Console.Write($"{badge.Key,-12}");
                string[] doorArray = badge.Value.ToArray();
                string seperateCards = string.Join(",", doorArray);
                Console.Write(seperateCards);
                Console.WriteLine();
            }
            AnyKey();
        }

        public void AddNewBadge()
        {
            Console.Clear();
            C3Badges newBadge = new C3Badges();
            Console.Write("Enter new badge ID: ");
            int userInput = int.Parse(Console.ReadLine());
            newBadge.BadgeID = userInput;
            Console.Write("Enter door badge needs access to (seperate by a comma): ");
            string input = Console.ReadLine();
            newBadge.DoorAccess = input.Split(',').ToList();
            bool wasAdded = _repo.AddNewBadge(newBadge);
            if (wasAdded)
            {
                Console.WriteLine("Badge created successfully.");
            }
            else
            {
                Console.WriteLine("Something went wrong, please try again.");
            }
            AnyKey();
        }

        public void UpdateDoorAcess()
        {
            Console.Clear();
            Dictionary<int, List<string>> badgeDictionary = _repo.GetAllBadges();
            Console.Write("Enter badge you wish to update: ");
            int badgeId = int.Parse(Console.ReadLine());
            List<string> doorsAvailable = new List<string>();
            bool hasBadge = badgeDictionary.TryGetValue(badgeId, out doorsAvailable);
            if (hasBadge)
            {
                bool continueToRun = true;
                while (continueToRun)
                {
                    Console.Clear();
                    Console.Write($"{badgeId} has access too ");
                    string[] doorArray = doorsAvailable.ToArray();
                    string seperatedDoors = string.Join(" & ", doorArray);
                    Console.Write(seperatedDoors);
                    Console.WriteLine();
                    Console.WriteLine("What would you like to do? \n" +
                        "1. Add door access \n" +
                        "2. Remove door access \n" +
                        "3. Exit");
                    string userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            Console.Write("Enter door to grant access: ");
                            string addInput = Console.ReadLine().ToUpper();
                            bool wasAdded = _repo.UpdateDoorInformation(badgeId, addInput);
                            if (wasAdded)
                            {
                                Console.WriteLine("Badge addedd successfully.");
                                AnyKey();
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong.");
                                AnyKey();
                            }
                            break;
                        case "2":
                            Console.Write("Enter door to remove access: ");
                            string removeInput = Console.ReadLine();
                            bool wasRemoved = _repo.RemoveDoorInformation(badgeId, removeInput);
                            if (wasRemoved)
                            {
                                Console.WriteLine("Door removed successfully.");
                                AnyKey();
                            }
                            else
                            {
                                Console.WriteLine("Something went wrong.");
                                AnyKey();
                            }
                            break;
                        case "3":
                            continueToRun = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid option.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("No such badge exists.");
                AnyKey();
            }
        }

        public void DeleteExistingBadge()
        {
            Console.Clear();
            Console.Write("Enter badge ID to delete: ");
            int userInput = int.Parse(Console.ReadLine());
            bool wasRemoved = _repo.RemoveBadge(userInput);
            if (wasRemoved)
            {
                Console.WriteLine("Badge deleted successfully.");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Something went wrong.");
                AnyKey();
            }
        }

        //Helper Methods
        public void SeedContent()
        {
            C3Badges badgeOne = new C3Badges(1234, new List<string>
            {
                "A1",
                "A2",
                "B1"
            });
            C3Badges badgeTwo = new C3Badges(2345, new List<string>
            {
                "B2",
                "C5",
                "C5"
            });
            C3Badges badgeThree = new C3Badges(4567, new List<string>
            {
                "A1",
                "B8",
                "D2"
            });

            _repo.AddNewBadge(badgeOne);
            _repo.AddNewBadge(badgeTwo);
            _repo.AddNewBadge(badgeThree);
        }

        public void AnyKey()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }
}
