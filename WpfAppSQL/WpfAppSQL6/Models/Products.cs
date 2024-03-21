namespace WpfAppSQL6.Models
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

    public class ExpensiveProducts
    {
        public string? TenMostExpensiveProducts { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
