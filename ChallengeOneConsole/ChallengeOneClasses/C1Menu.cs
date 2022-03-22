using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneConsole.ChallengeOneClasses
{
    public class C1Menu
    {
        
        public C1Menu () { }
        public C1Menu (int number, string name, string description, string ingredients, double price) 
        {
            Number = number;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; } //Made into string for ease of putting in menu items
        public double Price { get; set; }
    }
}
