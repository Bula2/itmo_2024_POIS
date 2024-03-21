using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppSQL9.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
        // Ссылка на покупателя
        public Customer Customer { get; set; }
        public override string ToString()
        {
            string s = ProductName + " " + Quantity + "шт., дата: " +
           PurchaseDate;
            return s;
        }
    }
}
