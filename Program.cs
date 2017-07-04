using System;

namespace _05.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();

            while (command != "END")
            {
                var tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (tokens[0])
                    {
                        case "Pizza":
                            AddPizza(tokens);
                            break;
                        case "Dough":
                            AddDough(tokens);
                            break;
                        case "Topping":
                            AddTopping(tokens);
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                command = Console.ReadLine();
            }
            
        }

        private static void AddTopping(string[] tokens)
        {
            Topping top = new Topping(tokens[1], double.Parse(tokens[2]));
            Console.WriteLine($"{top.CalculateToppingCalories():f2}");
        }

        private static void AddDough(string[] tokens)
        {
            Dough dough = new Dough(tokens[1], tokens[2], double.Parse(tokens[3]));
            Console.WriteLine($"{dough.CalculateDoughCalories():f2}");
        }

        private static void AddPizza(string[] tokens)
        {
            Pizza pizza = new Pizza(tokens[1], int.Parse(tokens[2]));

            tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Dough dough = new Dough(tokens[1], tokens[2], double.Parse(tokens[3]));
            pizza.Dough = dough;

            for (int i = 0; i < pizza.ToppingsCount; i++)
            {
                tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Topping top = new Topping(tokens[1], double.Parse(tokens[2]));
                pizza.AddToppingToPizza(top);
            }

            Console.WriteLine(pizza.ToString());
        }
    }
}
