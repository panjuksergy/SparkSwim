namespace SparkSwim.OrderService.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; } 
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsCanceled { get; set; }

        public IEnumerable<OrderArticle> OrderArticles { get; set; }
    }
}
