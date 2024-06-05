namespace PZ_Projekt.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DeliveryOption { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

