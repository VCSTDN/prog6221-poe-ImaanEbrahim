using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SANELEAPP_WPF.SANELEAPP_WPF.Class_Library;
using System.Windows;
using Microsoft.VisualBasic;


namespace SANELEAPP_WPF
{


    public partial class AddRecipeWindow : Window
    {
    
        public Recipe Recipe { get; private set; }

            public AddRecipeWindow()
            {
                InitializeComponent();
                Recipe = new Recipe();
                IngredientsListBox.ItemsSource = Recipe.Ingredients;
                StepsListBox.ItemsSource = Recipe.Steps;
            }

            private void AddIngredient_Click(object sender, RoutedEventArgs e)
            {
                var addIngredientWindow = new AddIngredientWindow();
                if (addIngredientWindow.ShowDialog() == true)
                {
                    Recipe.Ingredients.Add(addIngredientWindow.Ingredient);
                    IngredientsListBox.Items.Refresh();
                }
            }

        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            var step = Interaction.InputBox("Enter step description:", "Add Step", "");
            if (!string.IsNullOrWhiteSpace(step))
            {
                Recipe.Steps.Add(step);
                StepsListBox.Items.Refresh();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
            {
                Recipe.Name = RecipeNameTextBox.Text;
                DialogResult = true;
                Close();
            }

            private void Cancel_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = false;
                Close();
            }
        }
    }


