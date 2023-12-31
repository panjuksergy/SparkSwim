using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Exceptions;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService.Discounts.Commands.UpdateDiscount;

public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand>
{
    private readonly IProductDbContext _dbContext;

    public UpdateDiscountCommandHandler(IProductDbContext dbContext) => _dbContext = dbContext;

    public async Task Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
    {
        var existDiscount =
            await _dbContext.Discount.FirstOrDefaultAsync(_ => _.DiscountId == request.DiscountId, cancellationToken);
        
        if (existDiscount == null || existDiscount.DiscountId != request.DiscountId)
        {
            throw new NotFoundException(nameof(Discounts), request.DiscountId);
        }
        
        existDiscount.DiscountValue = request.DiscountValue;
        existDiscount.DateFrom = request.DateFrom;
        existDiscount.DateTo = request.DateTo;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}