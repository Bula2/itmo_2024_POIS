using LinqToDB.Mapping;

namespace WpfAppSQL8.Models
{
    // Определяем класс сущности Customer
    [Table(Name = "Customers")]
    public class Customer
    {
        [Column]
        public string? CustomerID { get; set; }

        [Column]
        public string? CompanyName { get; set; }

        [Column]
        public string? City { get; set; }


        public override string ToString()
        {
            return CustomerID + "\t" + City + "\t" + CompanyName;
        }
    }
}
