using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SANELEAPP_WPF.SANELEAPP_WPF.Class_Library;

namespace SANELEAPP_WPF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;

        public partial class MainWindow : Window
        {
            private List<Recipe> recipes = new List<Recipe>();
            private List<Recipe> filteredRecipes = new List<Recipe>();

            public MainWindow()
            {
                InitializeComponent();
                UpdateRecipeList();
            }

            private void AddRecipe_Click(object sender, RoutedEventArgs e)
            {
                var addRecipeWindow = new AddRecipeWindow();
                if (addRecipeWindow.ShowDialog() == true)
                {
                    recipes.Add(addRecipeWindow.Recipe);
                    UpdateRecipeList();
                }
            }

            private void FilterRecipes_Click(object sender, RoutedEventArgs e)
            {
                var filterWindow = new FilterWindow();
                if (filterWindow.ShowDialog() == true)
                {
                    var filter = filterWindow.Filter;
                filteredRecipes = recipes.Where(r =>
                (string.IsNullOrEmpty(filter.IngredientName) || r.Ingredients.Any(i => i.Name.IndexOf(filter.IngredientName, StringComparison.OrdinalIgnoreCase) >= 0)) &&
                (filter.FoodGroup == null || r.Ingredients.Any(i => i.FoodGroup == filter.FoodGroup)) &&
                (filter.MaxCalories == null || r.Ingredients.Sum(i => i.Calories)
                <= filter.MaxCalories)).ToList();
                UpdateRecipeList(true);
                }
            }

            private void ResetFilter_Click(object sender, RoutedEventArgs e)
            {
                filteredRecipes.Clear();
                UpdateRecipeList();
            }

            private void RecipeListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
            {
                if (RecipeListBox.SelectedItem is Recipe selectedRecipe)
                {
                    var recipeDetailsWindow = new RecipeDetailsWindow();
                    recipeDetailsWindow.Show();
                }
            }

            private void UpdateRecipeList(bool isFiltered = false)
            {
                RecipeListBox.ItemsSource = isFiltered ? filteredRecipes.OrderBy(r => r.Name).ToList() : recipes.OrderBy(r => r.Name).ToList();
            }
        }
    }


