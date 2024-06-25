using SANELEAPP_WPF.SANELEAPP_WPF.Class_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SANELEAPP_WPF
{
    public partial class RecipeDetailsWindow : Window
    {
        private Recipe recipe;
        public RecipeDetailsWindow()
        {
            InitializeComponent();
            this.recipe = recipe;
            LoadRecipeDetails();
        }


        private void LoadRecipeDetails()
        {
            RecipeNameLabel.Content = recipe.Name;
            IngredientsListBox.ItemsSource = recipe.Ingredients;
            StepsListBox.ItemsSource = recipe.Steps;
            TotalCaloriesLabel.Content = $"Total Calories: {recipe.Ingredients.Sum(i => i.Calories)}";

            if (recipe.Ingredients.Sum(i => i.Calories) > 300)
            {
                MessageBox.Show("The total calories of this recipe exceed 300!", "Calorie Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
