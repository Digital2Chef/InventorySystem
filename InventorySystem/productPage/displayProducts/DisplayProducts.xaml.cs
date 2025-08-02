using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace InventorySystem.productPage.displayProducts
{
    /// <summary>
    /// Interaction logic for DisplayProducts.xaml
    /// </summary>
    public partial class DisplayProducts : UserControl
    {
    
        public DisplayProducts()
        {
          
            InitializeComponent();
        }

        //method to add product to list of Product's class object Products! 
        private void save_Click(object sender, RoutedEventArgs e)
        {
            Product product = validateInputs();

            //validating user won't leave empty fields
            if (product != null)
            {

                //confirmation to add the product!
                confirmProduct(product);
                clearInputs();
            }

        }

        //method to validate inputs!
        private Product validateInputs()
        {
            //declaring variables to parse prices and quantity!
            int parsedQuantity;
            double parsedPurchasePrice;
            double parsedSellingPrice;
            bool isValid = true;


            //validating user won't leave emtpy fields
            if (string.IsNullOrEmpty(product_name.Text))
            {
                MessageBox.Show("Product name cannot be empty!");
                 isValid = false;
                return null;
            }
            if (string.IsNullOrEmpty(categories.Text))
            {
                MessageBox.Show("Category cannot be empty!");
                isValid = false;
                return null;
            }

            if (string.IsNullOrEmpty(description.Text))
            {
                MessageBox.Show("Description cannot be empty!");
                isValid = false;
                return null;
            }

            if (!int.TryParse(quantity.Text, out parsedQuantity) || parsedQuantity <= 0)
            {
                MessageBox.Show("Quantity must be a positive whole number.");
                isValid = false;
                return null;
            }
            if (!double.TryParse(purchase_price.Text, out parsedPurchasePrice) || parsedPurchasePrice <= 0)
            {
                MessageBox.Show("Purchase price  must be a positive whole number.");
                isValid = false;
                return null;
            }
            if (!double.TryParse(selling_price.Text, out parsedSellingPrice) || parsedSellingPrice <= 0)
            {
                MessageBox.Show("Selling price must be a positive whole number.");
                isValid = false;
                return null;
            }
            Product product = new Product
            {
                ProductName = product_name.Text,
                Quantity = parsedQuantity,
                PurchasePrice = parsedPurchasePrice,
                SellingPrice = parsedSellingPrice,
                Description = description.Text,
                Category = categories.Text,
            };
            //method to create product's id
            product.GenerateId();

            //method to calculate item's profit
            product.CalculateProfit();
            return product;

        }
    
        


        //method to confirm product
        private void confirmProduct(Product product)
        {
         var confirm =   MessageBox.Show($"Confirm product please.\n{product.ToString()}","confirm",MessageBoxButton.YesNo);//DISPLAY PRODUCT DETAILS 

            if (confirm == MessageBoxResult.Yes) 
            {
            
             ProductRepository.Products.Add(product); //adding product to the list!

            }
            else
            {
                MessageBox.Show("Product hadn't been  added to the list!");
                return;
            }


        }

        //method to clear out all input fields
        private void clearInputs()
        {
            product_name.Text = string.Empty;
            quantity.Text = string.Empty;
            purchase_price.Text = string.Empty;
            selling_price.Text = string.Empty;
            description.Text = string.Empty;
        }

        //method to cancel product addition
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);//creating a parent window's object
            parentWindow.Close();//closing parent window!
        }
    }
    }

