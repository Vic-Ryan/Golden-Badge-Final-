using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneConsole.ChallengeOneClasses
{
    public class C1MenuRepo
    {
        protected readonly List<C1Menu> _menuItemsDirectory = new List<C1Menu>();
        //Create
        public bool AddNewMenuItem (C1Menu menuItem)
        {
            int startingCount = _menuItemsDirectory.Count();
            _menuItemsDirectory.Add(menuItem);
            bool wasAdded = (_menuItemsDirectory.Count() > startingCount);
            return wasAdded;
        }
        //Read
        public List<C1Menu> GetAllItems()
        {
            return _menuItemsDirectory;
        }
        public C1Menu GetItemByNumber(int itemNumber)
        {
            return _menuItemsDirectory.Where(m => m.Number == itemNumber).SingleOrDefault();
        }
        //Delete
        public bool RemoveMenuItem (C1Menu menuItem)
        {
 
            bool deleteResult = _menuItemsDirectory.Remove(menuItem);
            return deleteResult;
        }
    }
}
