using MediatR;
using SparkSwim.GoodsService.Exceptions;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService.Discounts.Commands.DeleteDiscount;

public class DeleteProductCommandHandler : IRequestHandler<DeleteDiscountCommand>
{
    private readonly IProductDbContext _dbContext;

    public DeleteProductCommandHandler(IProductDbContext productDbContext)
    {
        _dbContext = productDbContext;
    }

    public async Task Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
    {
        var discountToDelete = await _dbContext.Discount.FindAsync(request.ProductId);

        if (discountToDelete == null || discountToDelete.ProductId != request.ProductId)
        {
            throw new NotFoundException(nameof(Products), request.ProductId);
        }

        _dbContext.Discount.Remove(discountToDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}