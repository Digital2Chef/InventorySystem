using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem
{
   public class User
    {
        //declaring variables
        private String username;
        private String password;

        //properties
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        //public constructor
        public User() { }


    }
}
