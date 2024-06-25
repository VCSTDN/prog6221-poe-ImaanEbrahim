
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using SANELEAPP_WPF.SANELEAPP_WPF.Class_Library;
  

namespace SANELEAPP_WPF
{
    public partial class AddIngredientWindow : Window
    {
       
        public Ingredient Ingredient { get; private set; }

        public AddIngredientWindow()
        {
            InitializeComponent();
            Ingredient = new Ingredient();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Ingredient.Name = IngredientNameTextBox.Text;
            Ingredient.Quantity = double.Parse(QuantityTextBox.Text);
            Ingredient.Unit = UnitTextBox.Text;
            Ingredient.Calories = int.Parse(CaloriesTextBox.Text);
            Ingredient.FoodGroup = (string)((ComboBoxItem)FoodGroupComboBox.SelectedItem).Content;
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
