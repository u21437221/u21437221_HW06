using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21437221_HW06.Models
{
    public class Order
    {
        public string ProductName { get; set; }
        public decimal ListPrice { get; set; }
        public int Quantity { get; set; } 
        public decimal Total { get; set; }
    }
}