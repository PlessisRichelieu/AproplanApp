using System;
using System.Collections.Generic;
using System.Text;

namespace ClassList
{
    public class Credentials
    {
        public string Alias;

        public string Pass;

        public Credentials (string userName, string password)
        {
            this.Alias = userName;
            this.Pass = password;
        }
    }
}
