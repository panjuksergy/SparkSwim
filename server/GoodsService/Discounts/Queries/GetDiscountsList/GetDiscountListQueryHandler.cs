using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;
using SparkSwim.GoodsService.Products.Queries.GetProductList;

namespace SparkSwim.GoodsService.Discounts.Queries.GetDiscountsList;

public class GetDiscountListQueryHandler : IRequestHandler<GetDiscountListQuery, DiscountListVm>
{
    private readonly IProductDbContext _productDbContext;
    private readonly IMapper _mapper;

    public GetDiscountListQueryHandler(IProductDbContext dbContext, IMapper mapper)
    {
        _productDbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<DiscountListVm> Handle(GetDiscountListQuery request, CancellationToken cancellationToken)
    {
        /// Entities with Discount in choosed category
        /// If category == null => Take discount from every category.

        var discounts = await (from discount in _productDbContext.Discount
            where (request.DateFrom == null || discount.DateFrom >= request.DateFrom)
                  && (request.DateTo == null || discount.DateTo <= request.DateTo)
                  && (request.DiscountValue == null || discount.DiscountValue >= request.DiscountValue)
            select discount).ProjectTo<DiscountLookUpDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

        return new DiscountListVm { Discounts = discounts };
    }
}