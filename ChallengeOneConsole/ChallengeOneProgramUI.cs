using ChallengeOneConsole.ChallengeOneClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneConsole
{
    public class ChallengeOneProgramUI
    {
        private readonly C1MenuRepo _repo = new C1MenuRepo();

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
                Console.WriteLine("Welcome to Komodo Cafe, please select an option: \n" +
                    "1. Show Full Menu \n" +
                    "2. Add new Menu Item \n" +
                    "3. Remove existing Menu Item \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowMenu();
                        break;
                    case "2":
                        AddMenuItem();
                        break;
                    case "3":
                        RemoveMenuItem();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter valid option");
                        AnyKey();
                        break;
                }
            }
        }

        public void ShowMenu()
        {
            Console.Clear();
            List<C1Menu> listOfItems = _repo.GetAllItems();
            foreach (C1Menu menuItem in listOfItems)
            {
                Console.WriteLine($"{menuItem.Number}. {menuItem.Name}\n" +
                $"${menuItem.Price}\n" +
                $"Description: {menuItem.Description}\n" +
                $"Ingredients: {menuItem.Ingredients}");
                Console.WriteLine();
            }
            AnyKey();
        }

        public void AddMenuItem()
        {
            List<C1Menu> listOfItems = _repo.GetAllItems();
            Console.Clear();
            C1Menu menuItem = new C1Menu();

            int numberOfItems = listOfItems.Count() + 1; //Adding one, since count starts at 0
            menuItem.Number = numberOfItems++; //Adds another one here, auto setting the number for the menu item, avoids going +2 each time.
            //Won't work too well when items removed, may try and add a more dynamic number system later on
            Console.Write("Please enter item name: ");
            menuItem.Name = Console.ReadLine();

            Console.Write("Please enter a description: ");
            menuItem.Description = Console.ReadLine();

            Console.Write("Please enter a price: ");
            menuItem.Price = decimal.Parse(Console.ReadLine());

            Console.Write("Please enter a list of ingredients: ");
            menuItem.Ingredients = Console.ReadLine();
            if (_repo.AddNewMenuItem(menuItem))
            {
                Console.WriteLine("Menu item added succesfully.");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Error in adding menu item.");
                AnyKey();
            }
        }

        public void RemoveMenuItem()
        {
            Console.Clear();
            List<C1Menu> listOfItems = _repo.GetAllItems();
            foreach (C1Menu menuItem in listOfItems)
            {
                Console.WriteLine($"{menuItem.Number}. {menuItem.Name}");
                Console.WriteLine();
            }
            Console.Write("Which menu item would you like removed? ");
            int targetItem = int.Parse(Console.ReadLine());
            int targetIndex = targetItem - 1;
            if (targetIndex >= 0 && targetIndex < listOfItems.Count)
            {
                C1Menu menuItem = listOfItems[targetIndex];
                if (_repo.RemoveMenuItem(menuItem))
                {
                    Console.WriteLine($"{menuItem.Name} successfully removed."); //More interactive feedback, specifically says what was removed 
                    foreach (C1Menu newMenu in listOfItems)
                    {
                        int menuNumber = listOfItems.IndexOf(newMenu) + 1;
                        newMenu.Number = menuNumber;
                    }
                }
                else
                {
                    Console.WriteLine("There was an error removing the menu item.");
                }
            }
            else
            {
                Console.WriteLine("No menu item found by that number.");
            }
            AnyKey();
        }

        //Helper Methods
        public void SeedContent()
        {
            C1Menu hotCoffee = new C1Menu(1, "Komodo Coffee", "A hot cup to start your day, or to help keep it going.", "Ground Coffee, Hot Water", 3.20m);
            C1Menu pancakes = new C1Menu(2, "Stack Overflow Flapjacks", "Keep up your hard work with a hardy stack of pancakes!", "Eggs, Milk, Pancake Batter", 7.99m);
            C1Menu omellette = new C1Menu(3, "Fresh Omelette", "A classic omellete, filled with meat and veggies.", "Eggs, sausage, bacon, peppers, onions", 8.45m);

            _repo.AddNewMenuItem(hotCoffee);
            _repo.AddNewMenuItem(pancakes);
            _repo.AddNewMenuItem(omellette);
        }
        public void AnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
