using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.Core.Exceptions;
using SparkSwim.OrderService.Interfaces;

namespace SparkSwim.OrderService.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler
        :IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderDbContext _context;

        public UpdateOrderCommandHandler(IOrderDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateOrderCommand request, 
            CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync
                (order => order.OrderId == request.OrderId, cancellationToken);

            if (order == null) 
            {
                throw new NotFoundException(nameof(order), request.OrderId);
            }

            order.FirstName = request.FirstName;
            order.SecondName = request.SecondName;
            order.Address = request.Address;
            order.Phone = request.Phone;
            order.Email = request.Email;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
