﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string PurchasedBy { get; set; }

        public Product(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
            PurchasedBy = null;
        }
    }
}
