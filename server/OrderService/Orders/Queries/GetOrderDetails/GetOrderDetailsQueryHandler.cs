using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.Core.Exceptions;
using SparkSwim.OrderService.Interfaces;

namespace SparkSwim.OrderService.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler
        : IRequestHandler<GetOrderDetailsQuery, OrderDetailsVm>
    {
        private readonly IOrderDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandler
            (IOrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDetailsVm> Handle
            (GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync
                (order => order.OrderId == request.Id, cancellationToken);

            if (order == null || order.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(order), request.Id);
            }

            return _mapper.Map<OrderDetailsVm>(order);
        }
    }
}
