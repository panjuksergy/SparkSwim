using MediatR;
using SparkSwim.OrderService.Interfaces;
using SparkSwim.OrderService.Models;

namespace SparkSwim.OrderService.OrderArticles.Commands.CreateOrderArticle
{
    public class CreateOrderArticleCommandHandler
        : IRequestHandler<CreateOrderArticleCommand, Guid>
    {
        private readonly IOrderDbContext _context;

        public CreateOrderArticleCommandHandler(IOrderDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateOrderArticleCommand request, 
            CancellationToken cancellationToken)
        {
            var orderArticle = new OrderArticle
            {
                Id = Guid.NewGuid(),
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                Price = request.Price,
            };

            await _context.OrderArticles.AddAsync(orderArticle, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return orderArticle.Id;
        }
    }
}
