using MediatR;

namespace SparkSwim.GoodsService.Discounts.Commands.CreateDiscount;

public class CreateDiscountCommand : IRequest<Guid>
{
    public ICollection<Guid> ProductsIds;
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal DiscountValue { get; set; }
}