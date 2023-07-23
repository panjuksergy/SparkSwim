using MediatR;
using Microsoft.AspNetCore.SignalR;
using SparkSwim.OrderService.Interfaces;
using SparkSwim.OrderService.Models;

namespace SparkSwim.OrderService.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler
        :IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderDbContext _context;

        public CreateOrderCommandHandler(IOrderDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, 
            CancellationToken cancellationToken)
        {
            var order = new Order
            {
                OrderId = Guid.NewGuid(),
                UserId = request.UserId,
                Address = request.Address,
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                Phone = request.Phone,
                Email = request.Email,
                CreationDate = DateTime.Now,
                IsCanceled = false
            };

            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return order.OrderId;
        }
    }
}
