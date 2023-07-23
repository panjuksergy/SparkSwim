using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.Core.Exceptions;
using SparkSwim.OrderService.Interfaces;
using SparkSwim.OrderService.Orders.Queries.GetOrderDetails;

namespace SparkSwim.OrderService.Orders.Queries.GetOrdersList
{
    public class GetOrderListQueryHandler
        : IRequestHandler<GetOrderListQuery, OrderListVm>
    {
        private readonly IOrderDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler
            (IOrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderListVm> Handle
            (GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var ordersQuery = await _context.Orders
                .Where(order => order.UserId == request.UserId)
                .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new OrderListVm { Orders = ordersQuery };
        }
    }
}
