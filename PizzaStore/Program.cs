using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    class Order
    {
        private List<Pizza> Pizzas;
        private List<Drink> Drinks;
        public Order()
        {
            Pizzas = new List<Pizza>();
            Drinks = new List<Drink>();
        }
        private Pizza OrderPizza()
        {
            PizzaBuilder pizzaBuilder = new PizzaBuilder();
            int choice = -1;
            Console.WriteLine("What pizza would you like?");
            Console.WriteLine("1. Pizza Margherita (tomato, cheese) 4.99$");
            Console.WriteLine("2. Hawaiian Pizza (tomato, cheese, ham, pineapple) 6.49$");
            Console.WriteLine("3. Salami Pizza (tomato, cheese, salami) 5.99$");
            while (choice < 0 || choice > 3)
            {
                Console.Write("Your pizza choice: ");
                try
                {
                    choice = Int16.Parse(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    Console.WriteLine("Invalid choice!");
                }
            }
            switch(choice)
            {
                case 2:
                    pizzaBuilder.AddHam();
                    pizzaBuilder.AddPineapple();
                    break;
                case 3:
                    pizzaBuilder.AddSalami();
                    break;
                default:
                    break;
            }
            choice = -1;
            Console.WriteLine("Would you like to add toppings?");
            Console.WriteLine("Notice: Depend on toppings, your pizza can change to another to save money!");
            Console.WriteLine("1. Cheese 0.69$");
            Console.WriteLine("2. Ham 0.99$");
            Console.WriteLine("3. Onion 0.69$");
            Console.WriteLine("4. Pineapple 0.79$");
            Console.WriteLine("5. Salami 0.99$");
            Console.WriteLine("6. Done!");
            while (choice != 6)
            {
                Console.Write("Your topping choice: ");
                try
                {
                    choice = Int16.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    choice = -1;
                }
                switch (choice)
                {
                    case 1:
                        pizzaBuilder.AddCheese();
                        break;
                    case 2:
                        pizzaBuilder.AddHam();
                        break;
                    case 3:
                        pizzaBuilder.AddOnion();
                        break;
                    case 4:
                        pizzaBuilder.AddPineapple();
                        break;
                    case 5:
                        pizzaBuilder.AddSalami();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Your choice is not in menu!");
                        break;
                }
            }
            Console.Write("Would you like family size? (Y for yes, any key for no) ");
            string isFamily = Console.ReadLine();
            if (isFamily.ToLower().CompareTo("y") == 0) pizzaBuilder.IsFamilySize = true;
            return pizzaBuilder.Build();
        }
        private Drink OrderDrink()
        {
            Drink drink = null;
            Console.WriteLine("** Drink Menu **");
            Console.WriteLine("1. Lemonade 1.29$");
            Console.WriteLine("2. Water 1.29$");
            Console.WriteLine("3. Wine 7.49$");
            int choice = -1;
            while(choice < 0 || choice > 3)
            {
                Console.Write("Your drink choice: ");
                try
                {
                    choice = Int16.Parse(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    choice = -1;
                }
                switch (choice)
                {
                    case 1:
                        drink = new Lemonade();
                        break;
                    case 2:
                        drink = new Water();
                        break;
                    case 3:
                        drink = new Wine();
                        break;
                    default:
                        Console.WriteLine("Your choice is not in menu!");
                        break;
                }
            }
            return drink;
        }
        private bool AddPizza(Pizza pizza)
        {
            if (pizza == null) return false;
            else
            {
                Pizzas.Add(pizza);
                return true;
            }
        }
        private bool AddDrink(Drink drink)
        {
            if (drink == null) return false;
            else
            {
                Drinks.Add(drink);
                return true;
            }
        }
        public void GetOrder()
        {
            Console.WriteLine("*** TastyPizza Inc ***");
            Console.WriteLine("Hi! Welcome to our store! What would you like to order?");
            int choice = -1;
            while (choice != 3)
            {
                Console.WriteLine("1. Pizza");
                Console.WriteLine("2. Drink");
                Console.WriteLine("3. Okay thats all!");
                Console.Write("Your menu choice: ");
                try
                {
                    choice = Int16.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    choice = -1;
                }
                switch (choice)
                {
                    case 1:
                        AddPizza(OrderPizza());
                        break;
                    case 2:
                        AddDrink(OrderDrink());
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Your choice is not in menu!");
                        break;
                }
            }
            Console.Write(this.GetDescription());
        }
        public string GetDescription()
        {
            var description = new StringBuilder();
            if (Drinks.Count == 0 && Pizzas.Count == 0) description.Append($"Thanks for visiting!\n");
            else
            {
                description.Append($"Your bill: \n");
                double total = 0;
                if (Pizzas.Count != 0)
                    foreach (Pizza pizza in Pizzas)
                    {
                        description.Append($"{pizza.GetDescription()}\n");
                        total += pizza.GetPrice();
                    }
                if (Drinks.Count != 0)
                    foreach (Drink drink in Drinks)
                    {
                        description.Append($"{drink.GetDescription()}\n");
                        total += drink.GetPrice();
                    }
                description.Append($"Total: {total:c}\n");
                description.Append($"Thanks for buying!\n");
            }
            return description.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Order cusOrder = new Order();
            cusOrder.GetOrder();
            Console.ReadKey();
        }
    }
}
