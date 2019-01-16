namespace MyApp.API.Models
{
    public class Cart
    {
        public Stock Item { get; set; }
        public int Amount { get; set; }
        public int Total { get; set; }
        public double Discount { get; set; }
    }
}