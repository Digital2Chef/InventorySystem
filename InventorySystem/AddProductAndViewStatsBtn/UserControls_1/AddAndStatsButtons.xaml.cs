using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace InventorySystem.AddProductAndViewStatsBtn.UserControls_1
{
    /// <summary>
    /// Interaction logic for AddAndStatsButtons.xaml
    /// </summary>
    public partial class AddAndStatsButtons : UserControl
    {
        public AddAndStatsButtons()
        {
            InitializeComponent();
        }



        //opening add product window
        private void add_product_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();//creating a new object to display add product page
            addProduct.ShowDialog();//displaying dialog window

        }

        //displaying window to view products for edit or delete!
        private void view_products_for_edit_delete_Click(object sender, RoutedEventArgs e)
        {
            if (ProductRepository.Products.Count > 0)
            {

                DisplayProductsPage displayProductsPage = new DisplayProductsPage();//creating a new object to open display products window
                displayProductsPage.ShowDialog();//displaying window
            }
            else
            {
                MessageBox.Show("There aren't any products currently available!");
                return;
            }
        }


        //displaying window to view total earnings
        private void view_earnings_Click(object sender, RoutedEventArgs e)
        {
            if(ProductRepository.Products.Count > 0)
            {
                //creating a new object for ProductProfit window
                ProductProfit productProfit = new ProductProfit(ProductRepository.Products);
                productProfit.ShowDialog();//displaying window
            }
            else
            {
                MessageBox.Show("There aren't any products currently available!");
                return;
            }
        }
    }
}
