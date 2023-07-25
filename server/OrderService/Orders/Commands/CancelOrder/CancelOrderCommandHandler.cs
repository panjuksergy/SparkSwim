using MediatR;
using SparkSwim.Core.Exceptions;
using SparkSwim.OrderService.Interfaces;

namespace SparkSwim.OrderService.Orders.Commands.DeleteOrder
{
    public class CancelOrderCommandHandler
        : IRequestHandler<CancelOrderCommand>
    {
        private readonly IOrderDbContext _orderDbContext;

        public CancelOrderCommandHandler(IOrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task Handle
            (CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _orderDbContext.Orders.FirstOrDefault
                (order => order.OrderId == request.OrderId);

            if (order == null && order.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(order), request.OrderId);
            }

            order.IsCanceled = true;

            await _orderDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}