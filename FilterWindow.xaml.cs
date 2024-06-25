using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SANELEAPP_WPF
{
   
        public partial class FilterWindow : Window
        {
            public Filter Filter { get; private set; }

            public FilterWindow()
            {
                InitializeComponent();
                Filter = new Filter();
            }

            private void Filter_Click(object sender, RoutedEventArgs e)
            {
                Filter.IngredientName = IngredientNameTextBox.Text;
                Filter.FoodGroup = FoodGroupComboBox.SelectedItem != null ? (string)((ComboBoxItem)FoodGroupComboBox.SelectedItem).Content : null;
                Filter.MaxCalories = int.TryParse(MaxCaloriesTextBox.Text, out int maxCalories) ? maxCalories : (int?)null;
                DialogResult = true;
                Close();
            }

            private void Cancel_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = false;
                Close();
            }
        }

        public class Filter
        {
            public string IngredientName { get; set; }
            public string FoodGroup { get; set; }
            public int? MaxCalories { get; set; }
        }
    }


