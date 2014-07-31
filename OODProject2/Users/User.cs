using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Users
{
    public class User
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; private set; }
        public Role Role { get; private set; }
        public Boolean gender { get; private set; }

        public void Login()
        {
        }

        public void Logout()
        {
        }

        public void ViewDashBoard()
        {
        }
    }
}
