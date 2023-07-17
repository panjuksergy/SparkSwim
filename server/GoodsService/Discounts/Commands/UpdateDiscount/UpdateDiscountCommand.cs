using MediatR;

namespace SparkSwim.GoodsService.Discounts.Commands.UpdateDiscount;

public class UpdateDiscountCommand : IRequest
{
    public Guid DiscountId { get; set; }
    public ICollection<Guid> ProductsIds { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal DiscountValue { get; set; }
}