using MediatR;

namespace SparkSwim.OrderService.Orders.Queries.GetOrdersList
{
    public class GetOrderListQuery : IRequest<OrderListVm>
    {
        public Guid UserId { get; set; }
    }
}
