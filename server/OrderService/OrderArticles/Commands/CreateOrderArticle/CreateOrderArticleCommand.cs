using MediatR;

namespace SparkSwim.OrderService.OrderArticles.Commands.CreateOrderArticle
{
    public class CreateOrderArticleCommand : IRequest<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
