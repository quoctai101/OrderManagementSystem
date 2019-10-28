using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    abstract class Drink
    {
        protected double Price;
        protected string Name;
        public double GetPrice()
        {
            return Price;
        }
        public string GetDescription()
        {
            return $"{this.Name} {this.Price:c}";
        }
    }
    class Lemonade : Drink
    {
        public Lemonade()
        {
            Price = 1.29;
            Name = "Lemonade";
        }
    }
    class Water : Drink
    {
        public Water()
        {
            Price = 1.29;
            Name = "Water";
        }
    }
    class Wine : Drink
    {
        public Wine()
        {
            Price = 7.49;
            Name = "Wine";
        }
    }
}
