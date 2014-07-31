using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODProject_2_.Users
{
    class UserFacade
    {
        // "no" means that user is not authenticated
        // "docs" means that user is a Senior Authority
        // "planning" means that user is an Intermediate Authority
        // "i audit" means that user is an Internal Inspector
        // "e audit" means that user is an External Inspector :D
        public static string IsAuthenticated(string username, string password)
        {
            if (username.Equals("maryam") && password.Equals("123"))
                return "docs";
            else if (username.Equals("zainab") && password.Equals("123"))
                return "planning";
            else if (username.Equals("shiva") && password.Equals("123"))
                return "i audit";
            else if (username.Equals("zarrin") && password.Equals("123"))
                return "e audit";
            else
                return "no";
        }

        // this function returns the specified user's gender
        public static Boolean GetUserGender(string username)
        {
            return true;
        }

        //this function returns the specified user's full name
        public static string GetUserFullName(string username)
        {
            if (username.Equals("maryam"))
                return "مریم پوررضا";
            else if (username.Equals("zainab"))
                return "زینب صادقی پور";
            else if (username.Equals("shiva"))
                return "شیوا کتابی";
            else if (username.Equals("zarrin"))
                return "زرین منتظری";
            return "";
        }
    }
}
