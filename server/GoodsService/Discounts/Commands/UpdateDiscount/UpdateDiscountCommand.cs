using MediatR;

namespace SparkSwim.GoodsService.Discounts.Commands.UpdateDiscount;

public class UpdateDiscountCommand : IRequest
{
    public Guid ProductId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal DiscountValue { get; set; }
}