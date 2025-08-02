using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ProductProfit.xaml
    /// </summary>
    public partial class ProductProfit : Window
    {
        public ProductProfit(ObservableCollection<Product> products)
        {
            InitializeComponent();
            

            //displaying only profit and product name
            profits.ItemsSource = products.Select(p =>
            {


                //calculating profit on live mode if it needs
                p.CalculateProfit();
                return p;
            }).ToList();
        }





        //terminating window
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        //method to export in csv form
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //creating a new SaveFileDialog object
            SaveFileDialog saveFile = new SaveFileDialog()

            {
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = "export_profit.csv"
            };

            //validating first
            if (saveFile.ShowDialog() == true)
            {
                try
                {
                    if (ProductRepository.Products == null)
                    {
                        MessageBox.Show("No products to export");
                        return;
                    }
                    else
                    {
                        //StreamWriter method to write in an excel file all data
                        using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                        {
                            //headers
                            sw.WriteLine("Product Name, Profit");

                            //writing data
                            foreach (var product in ProductRepository.Products) 
                            {
                                sw.WriteLine($"{product.ProductName.ToString()},{product.Profit.ToString()}");
                            }
                        }
                    }

                }
                catch (Exception ex) 
                {
                    MessageBox.Show($"Unexpected error occured:{ex.Message}");
                    return;
                }
            
            
            }

        }
    }
}
