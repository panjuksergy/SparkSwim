using MediatR;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService.Goods.Commands.CreateGood;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductDbContext _dbContext;
    public CreateProductCommandHandler(IProductDbContext dbContext) => _dbContext = dbContext;

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            ProductId = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            CreationDate = DateTime.Now,
            ProductImages = request.Images,
            ProductCount = request.ProductCount,
            Price = request.Price,
            Discount = request.Discount,
        };

        await _dbContext.Products.AddAsync(product, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return product.ProductId;
    }
}