namespace SparkSwim.OrderService.Models
{
    public class OrderArticle
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
    }
}
