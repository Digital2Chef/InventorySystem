using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InventorySystem
{
    /// <summary>
    /// Interaction logic for EditProductPanel.xaml
    /// </summary>
    public partial class EditProductPanel : Window
    {

        private Product editingProduct; //creating a new object to access selected item


        public EditProductPanel(Product product)
        {
            InitializeComponent();
            editingProduct = product;

            //getting the values from the list!
            edit_product_name.Text = editingProduct.ProductName;
            edit_categories.Text = editingProduct.Category;
            edit_quantity.Text = editingProduct.Quantity.ToString();
            edit_purchase_price.Text = editingProduct.PurchasePrice.ToString();
            edit_selling_price.Text = editingProduct.SellingPrice.ToString();
            edit_description.Text = editingProduct.Description;
        }

            //method to find selected combobox item

         private ComboBoxItem? FindComboBoxItem(ComboBox comboBox, string value)
        {
            foreach (ComboBoxItem item in comboBox.Items)
            {
                if ((item.Content as string)?.Equals(value, StringComparison.OrdinalIgnoreCase) == true)
                    return item;
            }
            return null;
        }  

        //method to update product
        private void edit_Click(object sender, RoutedEventArgs e)
        {
           

            if (!validateInputs(out int parsedQuantity, out double parsedPurchasePrice, out double parsedSellingPrice))
                return;
            { 


            //assigning new values in list's object
            editingProduct.ProductName = edit_product_name.Text;
            editingProduct.Category = edit_categories.Text;
                editingProduct.Quantity = parsedQuantity;
            editingProduct.PurchasePrice = parsedPurchasePrice;
            editingProduct.SellingPrice = parsedSellingPrice;
            editingProduct.Description = edit_description.Text;

            MessageBox.Show("Updated!");
            }
            

                clearInputs();//method to clear inputs!
        }


        //method to validate inputs!
        private bool validateInputs(out int parsedQuantity, out double parsedPurchasePrice , out double parsedSellingPrice)
        {
            parsedQuantity = 0;
            parsedPurchasePrice = 0;
            parsedSellingPrice = 0;

            //validating string won't be empty and user will enter numbers where it is required

            //validating product name input field
            if (string.IsNullOrEmpty(edit_product_name.Text))
            {
                MessageBox.Show("Product name can't be empty");
                return false;

            }

            //validating categories input field
            if (string.IsNullOrEmpty(edit_categories.Text))
            {
                MessageBox.Show("Category can't be empty");
                return false;

            }

            //validating quantity input field
            if (!int.TryParse(edit_quantity.Text, out parsedQuantity) || parsedQuantity <=0)
            {
                MessageBox.Show("Quantity can't be empty and must be a positive number");
                return false;
            }

            //validating purchase price input field
            if (!double.TryParse(edit_purchase_price.Text, out parsedPurchasePrice) || parsedPurchasePrice <= 0)
            {
                MessageBox.Show("Purchase price can't be empty and must be a positive number");
                return false;
            }

            //validating selling price input field
            if (!double.TryParse(edit_selling_price.Text, out parsedSellingPrice) || parsedSellingPrice <= 0)
            {
                MessageBox.Show("Selling price can't be empty and must be a positive number");
                return false;
            }

            //validating description
            if (string.IsNullOrEmpty(edit_description.Text))
            {
                MessageBox.Show("Description can't be empty");
                return false;

            }
            return true;
        }
        //method to clear inputs!
        private void clearInputs()
        {
            edit_product_name.Text= string.Empty;
            edit_categories.Text= string.Empty;
            edit_purchase_price.Text= string.Empty;
            edit_selling_price.Text = string.Empty;
            edit_quantity.Text= string.Empty;
            edit_description.Text= string.Empty;
        }

        //closing window
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
