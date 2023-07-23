using MediatR;

namespace SparkSwim.OrderService.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
