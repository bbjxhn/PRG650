using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibLoginAuthenticator
{
    public class LoginAuthenticator
    {
        public string username;
        public string password;

        public LoginAuthenticator()
        {
            username = null;
            password = null;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            private set { password = value; }
        }

        public bool? Authenticate()
        {
            string set_username = "john";
            string set_password = "doe";

            if (username != null && password != null)
            {
                if (username.Equals(set_username) && password.Equals(set_password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return null;
        }
    }
}
