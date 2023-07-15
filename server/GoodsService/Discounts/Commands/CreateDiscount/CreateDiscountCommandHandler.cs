using MediatR;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService.Discounts.Commands.CreateDiscount;

public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, Guid>
{
    private readonly IProductDbContext _dbContext;
    public CreateDiscountCommandHandler(IProductDbContext dbContext) => _dbContext = dbContext;

    public async Task<Guid> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var discount = new Discount
        {
            ProductId = Guid.NewGuid(),
            DateFrom = request.DateFrom,
            DateTo = request.DateTo,
            DiscountValue = request.DiscountValue
        };

        await _dbContext.Discount.AddAsync(discount, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return discount.ProductId;
    }
}