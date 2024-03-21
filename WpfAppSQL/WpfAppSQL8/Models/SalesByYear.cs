
namespace WpfAppSQL8.Models
{
    public class SalesByYear
    {
        public DateTime? ShippedDate { get; set; } 
        public int? OrderID {  get; set; } 
        public decimal? Subtotal { get; set; } 
        public string? Year { get; set; }
    }
}
