using MediatR;

namespace SparkSwim.OrderService.Orders.Commands.DeleteOrder
{
    public class CancelOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
    }
}
