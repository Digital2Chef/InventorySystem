using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace InventorySystem
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }




        //register logic!
        private void register_Click(object sender, RoutedEventArgs e)
        {
            //creating a new user!
            User user = new User();

            if (checkingUsername(username_register.Text))
            {
                MessageBox.Show("This username is already taken!");
                return;
            }

            if (validateInputsWereFilled() && arePassWordsEqual())
            {   
                    //passing values to the object's variables!
                    user.Username = username_register.Text;
                    user.Password = password_register.Password;

                    WriteData(user);//method to save data in the txt file!
                
            }
            clearnInputs();//method to clear inputs! 

            MainWindow main = new MainWindow();//creating a new main window's object
            main.Show();//displaying main window!
            this.Close();//closing this window!


            }

        //method to clear inputs
        private void clearnInputs()
        {
            //clearing inputs
            username_register.Text = string.Empty;
            password_register.Password = string.Empty;
            confirm_pass.Password = string.Empty;
        }

        //method to write data in a txt file!
        private void WriteData(User user)
        {
            var file = "users.txt";//creating a new variable to create the file doc

            try
            {
                //stream writer method to write data to the file!
                using (StreamWriter sw = new StreamWriter(file, append: true))
                {

                    sw.WriteLine($"{user.Username.Trim()}|{user.Password.Trim()}");
                    MessageBox.Show("Registration was successful!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error:{ex.Message}");
                return;
            }

        }

        //method to check if username already exists!
        private bool checkingUsername(string checkedUsername)
        {
            var file = "users.txt";

            if (!File.Exists(file))//returning false if file does not exists!
            {
                return false;
            }

           var lines = File.ReadAllLines(file);//reading all lines

            foreach (var line in lines) //foreach method to read all lines 1-1
            {
             var parts = line.Split('|');//trimming the "|" that splits username and pass!
             if(parts.Length > 1)
                {
                    var existingUsername = parts[0].Trim();
                    
                    if(string.Equals(existingUsername, checkedUsername.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
                         
            }
            return false;
        }

        //method to validate that user didn't left any empty input
        private bool validateInputsWereFilled()
        {
            //validating strings didn't left empty
            if (string.IsNullOrEmpty(username_register.Text) && string.IsNullOrEmpty(password_register.Password) && string.IsNullOrEmpty(confirm_pass.Password))
            {
                MessageBox.Show("Please fill out all the input fields!");
                return false;
            }
            return true;
        }

        //method to validate confirmation pass will be equals to regural pass
        private bool arePassWordsEqual()
        {
            //validating that pass will match with confirm pass

            if (password_register.Password != confirm_pass.Password)
            {
                MessageBox.Show("Passwords are not the same!");
                return false;

            }
            return true;
        }


        //closing registration window!
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();//creating a new main window's object
            main.Show();//displaying main window!
            this.Close();//closing this window!
        }
    }
}
