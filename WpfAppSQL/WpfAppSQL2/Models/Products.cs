using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppSQL2.Models
{
    public class Product: ProductShort
    {
        public decimal? UnitPrice { get; set; }
        public string? QuantityPerUnit { get; set; }
    }

    public class ProductShort
    {
        public string? ProductName { get; set; }
    }
}
