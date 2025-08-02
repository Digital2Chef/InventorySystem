using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InventorySystem
{
    public class Product : INotifyPropertyChanged
    {
        //declaring variables
        private String productName;
        private String category;
        private String description;
        private int quantity;
        private Double purchasePrice;
        private Double sellingPrice;
        private Double profit;
        private int productId;

        //random variable to create randomly an id
        private Random id = new Random();

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        //properties
        public string ProductName { get => productName;
             set
            {
                if (productName != value)
                {
                    productName = value;
                    OnPropertyChanged(nameof(ProductName));
                }

            } }
        public string Category { get => category; 
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged(nameof(Category));
                }

            }
        } 
        public string Description
        {
            get => description; set
            {
                if (description != value)
                {
                   description = value;
                    OnPropertyChanged(nameof(Description));
                }

            }
        }
        public int Quantity { get => quantity; 
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }

            }
        }
        public double PurchasePrice { get => purchasePrice; 
            set
            {
                if (purchasePrice != value)
                {
                    purchasePrice = value;
                    OnPropertyChanged(nameof(PurchasePrice));
                }

            }
        }
        public double SellingPrice { get => sellingPrice; 
            set
            {
                if (sellingPrice != value)
                {
                    sellingPrice = value;
                    OnPropertyChanged(nameof(SellingPrice));
                }

            }
        }
        public double Profit { get => profit; 
            set
            {
                if (profit != value)
                {
                    profit = value;
                    OnPropertyChanged(nameof(Profit));
                }

            }
        }
        public int ProductId { get => productId; 
            set
            {
                if (productId != value)
                {
                    productId = value;
                    OnPropertyChanged(nameof(ProductId));
                }

            }
        }


        //creating an empty constructor
        public Product() { }

        //method to create a six digits random id
        public int GenerateId()
        {
           ProductId = id.Next(10000,100000);
            return ProductId;
        }
      
        //method to calculate profit
        public double CalculateProfit()
        {
            double itemProfit;

            itemProfit = SellingPrice - PurchasePrice;
            Profit = itemProfit * Quantity;
            return Profit;
        }
         

        public override string  ToString()
        {
            return $"Product Id:{ProductId}\n" +
                   $"Product name:{ProductName}\n"+
                   $"Category:{Category}\n"+
                   $"Quantity:{Quantity}\n" +
                   $"Purchase Price:{PurchasePrice}\n" +
                   $"Selling Price:{SellingPrice}\n" +
                   $"Description:{Description}\n"+
                   $"Profit:{Profit}\n";
        }
    }
}
