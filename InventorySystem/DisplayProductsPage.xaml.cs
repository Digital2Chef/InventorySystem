using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Shapes;

namespace InventorySystem
{
    /// <summary>
    /// Interaction logic for DisplayProductsPage.xaml
    /// </summary>
    public partial class DisplayProductsPage : Window
    {
        public DisplayProductsPage()
        {
            InitializeComponent();
            productList.ItemsSource = ProductRepository.Products;
        }

        //method to close this window
        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //helping method to clear white spaces etc
        private string EscapeCSV(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "";
            }
            if (value.Contains("'") || value.Contains("\"") || value.Contains("\n"))
            {
                return $"\"{value.Replace("\"", "\"\"")}\"";
            }
            return value;
        }

        //export to csv btn
        private void csv_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog()//creating a new object to save data
            {
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = "products_export.csv"
            };
            if (saveFile.ShowDialog() == true)
            {
                try
                {

                    if (ProductRepository.Products == null)
                    {
                        MessageBox.Show("No items to export.", "error");
                        return;
                    }

                    using (StreamWriter sv = new StreamWriter(saveFile.FileName, false, Encoding.UTF8))
                    {
                        //header
                        sv.WriteLine("ProductId, ProductName, Category, Quantity, PurchasePrice, SellingPrice, Description, Profit");

                        //data rows
                        foreach (var p in ProductRepository.Products)
                        {

                            sv.WriteLine($"{p.ProductId.ToString()},{EscapeCSV(p.ProductName.ToString())}, {EscapeCSV(p.Category)}," +
                                $" {EscapeCSV(p.Quantity.ToString())},{EscapeCSV(p.PurchasePrice.ToString())}," +
                                $" {EscapeCSV(p.SellingPrice.ToString())}," +
                                $" {EscapeCSV(p.Description.ToString())}, {EscapeCSV(p.Profit.ToString())}");

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting to csv:{ex.Message}", "Error");
                    return;
                }


            }

        }


        //Method to delete program
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (productList.SelectedItems.Count > 0) { 
            if (productList.SelectedItem is Product selectedProduct)
            {
                var result = MessageBox.Show("Are you sure you want to delete existing item?", "warning", MessageBoxButton.YesNo);//validating that user wants to delete product 
                if (result == MessageBoxResult.Yes)
                {
                    ProductRepository.Products.Remove(selectedProduct);//removing product

                }
                else
                {
                    MessageBox.Show("You chose to keep this product in the list");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please choose a product to delete!");
                return;
            }
            }
            else
            {
                MessageBox.Show("There aren't any stored products to delete!");
                return;
            }
        }


        //method to open edit product panel
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (productList.SelectedItem is Product selectedProduct)
            {

                //creating a new window to display edit panel
                EditProductPanel editProduct = new EditProductPanel(selectedProduct);
                editProduct.ShowDialog();//displaying window!

            }
            else
            {
                MessageBox.Show("You haven't chosen a product to edit");
                return;
            }
        }
    }
}
