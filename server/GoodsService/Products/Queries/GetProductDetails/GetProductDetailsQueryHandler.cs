using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Common.Mapping;
using SparkSwim.GoodsService.Exceptions;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService.Products.Queries.GetProduct;

public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsVm>
{
    private readonly IProductDbContext _productDbContext;
    private readonly IMapper _mapper;

    public GetProductDetailsQueryHandler(IProductDbContext dbContext, IMapper mapper)
    {
        _productDbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ProductDetailsVm> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity =
            await _productDbContext.Products.FirstOrDefaultAsync(_ => _.ProductId == request.ProductId,
                cancellationToken);
        if (entity == null || entity.ProductId != request.ProductId)
        {
            throw new NotFoundException(nameof(Product), request.ProductId);
        }

        return _mapper.Map<ProductDetailsVm>(entity);    }
}