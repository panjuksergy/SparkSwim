using MediatR;

namespace SparkSwim.GoodsService.Discounts.Queries.GetDiscount;

public class GetDiscountQuery : IRequest<DiscountVm>
{
    public Guid DiscountId { get; set; }
}