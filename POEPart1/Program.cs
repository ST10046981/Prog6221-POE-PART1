// See https://aka.ms/new-console-template for more information
//By Neo Sedikane ST10046981
using System;
using System.Collections;
using System.ComponentModel;
using System.Transactions;

public class Ingredient
{
    public string IngName;
    public double Quantity;
    public string Unit;
    public double OgQuantity;

    public Ingredient(string name, double quantity, string unit)
    {
        IngName = name;
        Quantity = quantity;
        Unit = unit;
        OgQuantity = quantity;
    }
}

class Recipe
{
    public string meal;
    public int numIngredients;
    public int numSteps;
    //list to store ingredients
    public List<Ingredient> Ingredients;
    //list to store steps
    public List<string> Steps = new List<string>();

    public Recipe()
    {
        Ingredients = new List<Ingredient>();
        Steps = new List<string>();
    }

    //This method takes inputed values and adds them to the ingredients list
    public void addIng(string name, double quantity, string unit)
    {
        Ingredients.Add(new Ingredient(name, quantity, unit));
    }

    //This method takes inputed values and adds them to the steps list
    public void addSteps(string stepsTaken)
    {
        Steps.Add(stepsTaken);
    }

    //this method displays the recipe and steps
    public void displayRecipe() 
    {
        Console.WriteLine("INGREDIENTS:");
        foreach(var ingredients in Ingredients)
        {
            Console.WriteLine($"Name:{ingredients.IngName} \nQuantity:{ingredients.Quantity} \nUnit:{ingredients.Unit}");
        }

        Console.WriteLine("STEPS:");
        foreach (var steps in Steps)
        {
            Console.WriteLine(steps);
        }
    }
    //method to do the scale up calculation
    public void ScaleUp(double num)
    {
        foreach(var ingredients in Ingredients)
        {
            ingredients.Quantity = num * ingredients.Quantity;
        }
    }
    //method to fetch the original quantity
    public void reset()
    {
        foreach (var ingredients in Ingredients)
        {
            ingredients.Quantity = ingredients.OgQuantity;
        }
    }
    //method to clear the data initially inserted
    public void clear()
    {
        Ingredients.Clear();
        Steps.Clear();
    }

}

class Cook
{
    //main code
    public static void Main(string[] args)
    {
        program();
    }
    //h
    public static void program()
    {
        Recipe recipe = new Recipe();
        Console.Write("Enter meal name: ");
        recipe.meal = Console.ReadLine();
        Console.Write("How many ingredients do we need: ");
        recipe.numIngredients = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < recipe.numIngredients; i++)
        {
            Console.Write("Enter ingredient: ");
            string name = Console.ReadLine();
            Console.Write("Enter quantity: ");
            double quantity = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter unit: ");
            string unit = Console.ReadLine();
            Console.WriteLine();

            recipe.addIng(name, quantity, unit);
        }

        Console.WriteLine();
        Console.Write("How many steps do we need: ");
        recipe.numSteps = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < recipe.numSteps; i++)
        {
            Console.Write("Describe step " + (i + 1) + ":");
            string step = Console.ReadLine();

            recipe.addSteps(step);
        }

        recipe.displayRecipe();

        Console.Write("Do you want to scale up? Type 'y' or 'n': ");
        string responce = Console.ReadLine();

        if (responce == "y")
        {
            Console.WriteLine("To scale up enter a factor to scale up to (0.5, 2, 3)");
            double number = double.Parse(Console.ReadLine());
            recipe.ScaleUp(number);

            recipe.displayRecipe();
            Console.WriteLine();
            Console.WriteLine("Do you want to reset to origianl quantities? type 'y' or 'n': ");
            string answer = Console.ReadLine();

            if (answer == "y")
            {
                recipe.reset();
                Console.WriteLine();
                recipe.displayRecipe();

                Console.WriteLine("Do you want to clear or end program? enter 'c' or 'e': ");
                string ans = Console.ReadLine();

                if (ans == "c")
                {
                    recipe.clear();
                    Console.WriteLine("Do you want to re-enter a new recipe? enter 'y' or 'n': ");
                    string rec = Console.ReadLine();
                    if(rec == "y")
                    {
                        program();
                    }

                    if(rec == "n")
                    {
                        Console.WriteLine("End of program");
                    }
                }
                if (ans == "e")
                {
                    Console.WriteLine("End of program");
                }
            }

            if(answer == "n")
            {
                Console.WriteLine("Do you want to clear? type 'y' or 'n': ");
                string ans = Console.ReadLine();

                if(ans == "y")
                {
                    recipe.clear();
                    Console.WriteLine("Do you want to re-enter? enter 'y' or 'n': ");
                    string rec = Console.ReadLine();
                    if (rec == "y")
                    {
                        program();
                    }

                    if (rec == "n")
                    {
                        Console.WriteLine("End of program");
                    }
                }
                if (ans == "n")
                {
                    Console.WriteLine("End of program");
                }
            }

        }
        if(responce == "n")
        {
            Console.WriteLine("Do you want to clear? type 'y' or 'n': ");
            string ans = Console.ReadLine();

            if (ans == "y")
            {
                recipe.clear();
                Console.WriteLine("Do you want to re-enter? enter 'y' or 'n': ");
                string rec = Console.ReadLine();
                if (rec == "y")
                {
                    program();
                }

                if (rec == "n")
                {
                    Console.WriteLine("End of program");
                }
            }
            if (ans == "n")
            {
                Console.WriteLine("End of program");
            }
        }

    }

    

    
}

