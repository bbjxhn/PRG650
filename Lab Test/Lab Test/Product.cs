using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Test
{
    public class Product
    {
        protected string Code;
        public string firstname;
        public string lastname;

        public Product() {
            firstname = string.Empty;
            lastname = string.Empty;
        }

        public virtual string GetInfo()
        {
            return Code;
        }
    }
}
