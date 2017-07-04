using System;
using System.Collections.Generic;

namespace _05.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private int toppingsCount;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, int toppingsCount)
        {
            this.Name = name;
            this.ToppingsCount = toppingsCount;
            this.toppings = new List<Topping>();
        }


        public string Name
        {
            get { return this.name; }
            private set
            {
                if(value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public int ToppingsCount
        {
            get { return this.toppingsCount; }
            private set
            {
                if(value < 0 || value > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                this.toppingsCount = value;
            }
        }

        public double CalculateTotalCalories()
        {
            var result = 0d;
            result += this.dough.CalculateDoughCalories();

            for (int i = 0; i < this.ToppingsCount; i++)
            {
               result += this.toppings[i].CalculateToppingCalories();
            }
            
            return result;
        }

        public Dough Dough
        {
            set { this.dough = value; }
        }

        public void AddToppingToPizza(Topping topping)
        {
            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} – {this.CalculateTotalCalories():f2} Calories.";
        }
    }
}
