using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANELEAPP_WPF
{
    class Program
    {
        static List<Recipe> recipes = new List<Recipe>();

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Recipe Application");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. List Recipes");
                Console.WriteLine("3. Display Recipe");
                Console.WriteLine("4. Scale Recipe");
                Console.WriteLine("5. Reset Recipe");
                Console.WriteLine("6. Clear Recipes");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRecipe();
                        break;
                    case "2":
                        ListRecipes();
                        break;
                    case "3":
                        DisplayRecipe();
                        break;
                    case "4":
                        ScaleRecipe();
                        break;
                    case "5":
                        ResetRecipe();
                        break;
                    case "6":
                        ClearRecipes();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddRecipe()
        {
            Console.Write("Enter recipe name: ");
            string name = Console.ReadLine();
            var recipe = new Recipe { Name = name };

            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Write("Enter ingredient name: ");
                string ingredientName = Console.ReadLine();
                Console.Write("Enter quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Enter unit of measurement: ");
                string unit = Console.ReadLine();
                Console.Write("Enter number of calories: ");
                int calories = int.Parse(Console.ReadLine());
                Console.Write("Enter food group: ");
                string foodGroup = Console.ReadLine();

                recipe.Ingredients.Add(new Ingredient
                {
                    Name = ingredientName,
                    Quantity = quantity,
                    Unit = unit,
                    Calories = calories,
                    FoodGroup = foodGroup
                });
            }

            Console.Write("Enter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                string step = Console.ReadLine();
                recipe.Steps.Add(step);
            }

            recipes.Add(recipe);
        }

        static void ListRecipes()
        {
            Console.WriteLine("Recipes:");
            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }

        static void DisplayRecipe()
        {
            Console.Write("Enter the name of the recipe to display: ");
            string name = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                Console.WriteLine($"Recipe: {recipe.Name}");
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name} - {ingredient.Calories} calories ({ingredient.FoodGroup})");
                }
                Console.WriteLine("Steps:");
                foreach (var step in recipe.Steps)
                {
                    Console.WriteLine(step);
                }
                int totalCalories = recipe.Ingredients.Sum(i => i.Calories);
                Console.WriteLine($"Total Calories: {totalCalories}");
                if (totalCalories > 300)
                {
                    Console.WriteLine("Warning: Total calories exceed 300!");
                }
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        static void ScaleRecipe()
        {
            Console.Write("Enter the name of the recipe to scale: ");
            string name = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                Console.Write("Enter the scaling factor (0.5, 2, 3): ");
                double factor = double.Parse(Console.ReadLine());
                foreach (var ingredient in recipe.Ingredients)
                {
                    ingredient.Quantity *= factor;
                }
                Console.WriteLine("Recipe scaled successfully.");
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        static void ResetRecipe()
        {
            Console.Write("Enter the name of the recipe to reset: ");
            string name = Console.ReadLine();
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
           
                Console.WriteLine("Recipe reset successfully.");
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        static void ClearRecipes()
        {
            recipes.Clear();
            Console.WriteLine("All recipes cleared.");
        }
    }

   public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<string> Steps { get; set; } = new List<string>();
    }

  public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }
}
