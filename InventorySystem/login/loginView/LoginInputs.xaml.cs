using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventorySystem.login.loginView
{
    /// <summary>
    /// Reset login window after registration, to avoid reduced login attempts!
    /// </summary>
    public partial class LoginInputs : UserControl
    {

        

        //declaring a variable counter = 3 to reduce for each fail attempt. When counter reaches 0 account will get locked!
        int counter = 3;
        public LoginInputs()
        {
            InitializeComponent();
        }

        //Method to validate string won't be null 
        private bool isStringFilled()
        {
            if (string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(password.Password))
            {
               
                return false;
            }
            return true;
        }

        //method to validate inputs!
        private bool validateInputs(string enteredUsername, string enteredPassword)
        {
           
            var file = "users.txt";//creating a variable to store file's name
            if (!File.Exists(file)) 
            {
                MessageBox.Show("There isn't any user registered yet!");
                return false;
            }

            var line = File.ReadLines(file);//reading all lines

            //foreach method to read all lines one by one!
            foreach (var lines in line)
            {
                var parts = lines.Split('|');//reading lines without "|" symbol
                if(parts.Length == 2)
                {
                    string storedUsername = parts[0].Trim();
                    string storedPassword = parts[1].Trim();    

                    if(string.Equals(storedUsername, enteredUsername.Trim(), StringComparison.OrdinalIgnoreCase ) && storedPassword == enteredPassword)
                    {
                        return true;
                    }
                }
               
            }
            
            return false;

        }

        //login logic!
        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (isStringFilled()) { 
            //declaring variables
            string enteredUsername = username.Text; 
            string enteredPassword = password.Password;

            if (validateInputs(enteredUsername,enteredPassword))
            {
                MessageBox.Show("Logged in!");
                displayDashBoard();//method to display dashboard window after successful login attempt!

               
            }
            else
            {
                //reducing login attempts
                counter--;
                MessageBox.Show($"Invalid credentials.{counter} attempts remain");
                                               
            }
            if (counter == 0)
            {
                MessageBox.Show("Account locked due to a lot failed login attempts");
                Environment.Exit(0);//terminating app

              
            }
            }
            else
            {
                MessageBox.Show("Input fields left empty");
            }

                //clearing inputs!
                clearInputs();
        }


        //method to clear inputs
        private void clearInputs()
        {
            username.Text = string.Empty;
            password.Password = string.Empty;
        }
        //method to open dashboard window
        private void displayDashBoard()
        {

            InventoryDashboard inventoryDashboard = new InventoryDashboard();//creating a new window's object
            inventoryDashboard.Show();//displaying new window
            
            Window parentWindow = Window.GetWindow(this);//creating an object from main window!
            parentWindow.Close();//closing parent window!
        }


        //closing application!
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            var confirmation = MessageBox.Show("Are you sure you want to terminate app?","attention",MessageBoxButton.YesNo);

            if (confirmation == MessageBoxResult.Yes)
            {
                MessageBox.Show("Thanks for using my app!");
                Environment.Exit(0);//terminating app


            }
        }


        //opening register window
        private void register_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();//creating a new object to assign register window
            register.Show();//displaying register window!

            Window parentWindow = Window.GetWindow(this);//creating an object from main window!
            parentWindow.Close();//closing parent window!
        }
    }
}
