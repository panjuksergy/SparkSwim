using MediatR;

namespace SparkSwim.OrderService.OrderArticles.Commands.UpdateOrderArticle
{
    public class UpdateOrderArticleCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
