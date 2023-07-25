using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.Core.Exceptions;
using SparkSwim.OrderService.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SparkSwim.OrderService.OrderArticles.Commands.UpdateOrderArticle
{
    public class UpdateOrderArticleCommandHandler
        : IRequestHandler<UpdateOrderArticleCommand>
    {
        IOrderDbContext _context;

        public UpdateOrderArticleCommandHandler(IOrderDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateOrderArticleCommand request, 
            CancellationToken cancellationToken)
        {
            var orderArticle = await _context.OrderArticles.FirstOrDefaultAsync
                (orderArticle => orderArticle.Id == request.Id, cancellationToken);

            if (orderArticle == null)
            {
                throw new NotFoundException(nameof(orderArticle), request.Id);
            }

            orderArticle.ProductId = request.ProductId;
            orderArticle.ProductName = request.ProductName;
            orderArticle.Price = request.Price;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
