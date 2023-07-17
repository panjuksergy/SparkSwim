using MediatR;

namespace SparkSwim.GoodsService.Discounts.Commands.DeleteDiscount;

public class DeleteDiscountCommand : IRequest
{
    public Guid DiscountId { get; set; }
}