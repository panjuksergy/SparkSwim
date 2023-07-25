using MediatR;

namespace SparkSwim.OrderService.OrderArticles.Queries.GetOrderArticleDetails
{
    public class GetOrderArticleDetailsQuery : IRequest<OrderArticleDetailsVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
