using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Goods.Models;
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
        /// If request filters is null, it will be ignored on filtering

        IQueryable<Product> productsQuery = _productDbContext.Products.AsQueryable();

        productsQuery = productsQuery
            .Where(p => (request.PriceFrom == null || p.Price >= request.PriceFrom)
                        && (request.PriceTo == null || p.Price <= request.PriceTo)
                        && (request.ProductType == null || p.ProductType == request.ProductType));

        var products = await productsQuery
            .Skip(request.NumberFromToSkip)
            .Take(request.CountToGet)
            .ProjectTo<ProductLookUpDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ProductListVm { Products = products };
    }
}