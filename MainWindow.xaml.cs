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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
                InitializeComponent();
                LoadData();
        }

        private void LoadData()
        {
            productGrid.ItemsSource = new List<object>
            {
                new { Name = "Gaming Laptop", Category = "Electronics", Price = "Rs. 120,000", Status = "In Stock" },
                new { Name = "Wireless Headphones", Category = "Accessories", Price = "Rs. 5,500", Status = "Limited Stock" },
                new { Name = "Smart Watch", Category = "Wearables", Price = "Rs. 12,000", Status = "Out of Stock" },
                new { Name = "Mechanical Keyboard", Category = "Accessories", Price = "Rs. 8,500", Status = "In Stock" },
                new { Name = "Gaming Mouse", Category = "Accessories", Price = "Rs. 3,200", Status = "In Stock" }
            };
        }

            // HOME BUTTON CLICK
        private void Home_Click(object sender, RoutedEventArgs e)
        {
                HomeSection.Visibility = Visibility.Visible;
                ProductSection.Visibility = Visibility.Collapsed;
        }

            // PRODUCTS BUTTON CLICK
        private void Products_Click(object sender, RoutedEventArgs e)
        {
                HomeSection.Visibility = Visibility.Collapsed;
                ProductSection.Visibility = Visibility.Visible;
        }

            // SETTINGS BUTTON CLICK
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
                MessageBox.Show("Settings for Rabeea: Theme and Profile options coming soon!", "Settings");
        }

        // SEARCH LOGIC
        private void SearchBar_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string searchText = searchBar.Text.ToLower();
            if (productGrid.ItemsSource != null)
            {
                var view = CollectionViewSource.GetDefaultView(productGrid.ItemsSource);
                view.Filter = (obj) =>
                {
                    var item = obj as dynamic;
                    return string.IsNullOrEmpty(searchText) || item.Name.ToLower().Contains(searchText);
                };

            }
        }
    }
}