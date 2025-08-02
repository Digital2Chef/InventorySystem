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
using System.Windows.Shapes;

namespace InventorySystem
{
    /// <summary>
    /// Interaction logic for InventoryDashboard.xaml
    /// </summary>
    public partial class InventoryDashboard : Window
    {


        //creating a new observable list object form class Product
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public InventoryDashboard()
        {
            InitializeComponent();
        }

       


        //terminate app btn!
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to logout?", "warning", MessageBoxButton.YesNo);
            if(confirm == MessageBoxResult.Yes)
            {
                MessageBox.Show("Bye Bye");
                MainWindow main = new MainWindow();//creating an object to display login page
                main.Show();//displaying login page!
                this.Close();//closing this window
            }
            else
            {
                MessageBox.Show("Thank you for not leaving");
                return;
            }
        }

       
    }
}
