using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Exceptions;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductDbContext _dbContext;

    public UpdateProductCommandHandler(IProductDbContext dbContext) => _dbContext = dbContext;
    
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var existProduct = await _dbContext.Products.FirstOrDefaultAsync(_ => _.ProductId == request.ProductId, cancellationToken);

        if (existProduct == null || existProduct.ProductId != request.ProductId)
        {
            throw new NotFoundException(nameof(Products), request.ProductId);
        }

        existProduct.Title = request.Title;
        existProduct.Description = request.Description;
        existProduct.CreationDate = DateTime.Now;
        existProduct.Price = request.Price;
        existProduct.ProductImages = request.Images;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}