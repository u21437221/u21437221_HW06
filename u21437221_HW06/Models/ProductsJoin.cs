using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21437221_HW06.Models
{
    public class ProductsJoin
    {
        public product ProductDetails { get; set; }
        public brand BrandDetails { get; set; }
        public category CategoryDetails { get; set; }
        public stock StockDetails { get; set; }
    }
}