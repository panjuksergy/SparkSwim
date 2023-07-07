using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductDbContext _dbContext;

        public DeleteProductCommandHandler(IProductDbContext productDbContext)
        {
            _dbContext = productDbContext;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _dbContext.Products.FindAsync(request.Id);
            
        }
    }
}