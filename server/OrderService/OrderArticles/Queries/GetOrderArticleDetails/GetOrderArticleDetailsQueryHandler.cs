using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SparkSwim.Core.Exceptions;
using SparkSwim.OrderService.Interfaces;
using SparkSwim.OrderService.Models;

namespace SparkSwim.OrderService.OrderArticles.Queries.GetOrderArticleDetails
{
    public class GetOrderArticleDetailsQueryHandler
        : IRequestHandler<GetOrderArticleDetailsQuery, OrderArticleDetailsVm>
    {
        private readonly IOrderDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderArticleDetailsQueryHandler(IOrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderArticleDetailsVm> Handle(GetOrderArticleDetailsQuery request, 
            CancellationToken cancellationToken)
        {
            var orderArticle = await _context.OrderArticles
                .Include(orderArticle => orderArticle.Order)
                .FirstOrDefaultAsync(orderArticle => orderArticle.Id == request.Id);

            if (orderArticle == null || orderArticle.Order.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(orderArticle), request.Id);
            }

            return _mapper.Map<OrderArticleDetailsVm>(orderArticle);
        }
    }
} 