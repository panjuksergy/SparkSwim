using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Exceptions;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService.Discounts.Queries.GetDiscount;

public class GetDiscountQueryHandler: IRequestHandler<GetDiscountQuery, DiscountVm>
{
    private readonly IProductDbContext _productDbContext;
    private readonly IMapper _mapper;

    public GetDiscountQueryHandler(IProductDbContext dbContext, IMapper mapper)
    {
        _productDbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<DiscountVm> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        var entity =
            await _productDbContext.Discount.FirstOrDefaultAsync(_ => _.ProductId == request.ProductId,
                cancellationToken);
        if (entity == null || entity.ProductId != request.ProductId)
        {
            throw new NotFoundException(nameof(Product), request.ProductId);
        }

        return _mapper.Map<DiscountVm>(entity);
    }
}