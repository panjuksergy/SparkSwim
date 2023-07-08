using AutoMapper;
using MediatR;
using SparkSwim.GoodsService.Interfaces;
using SparkSwim.GoodsService.Products.Queries.GetProduct;

namespace SparkSwim.GoodsService.Products.Queries.GetProductList;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ProductListVm>
{
    private readonly IProductDbContext _productDbContext;
    private readonly IMapper _mapper;

    public GetProductListQueryHandler(IProductDbContext dbContext, IMapper mapper)
    {
        _productDbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<ProductListVm> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var productsQuery = await _productDbContext.Products.Where()
    }
}