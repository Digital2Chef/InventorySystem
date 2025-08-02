using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
    /// <summary>
    /// this is a public class to store a usable list from every class
    /// </summary>
   public static class ProductRepository
    {

        public static ObservableCollection<Product> Products { get; } = new ObservableCollection<Product>();



    }
}
