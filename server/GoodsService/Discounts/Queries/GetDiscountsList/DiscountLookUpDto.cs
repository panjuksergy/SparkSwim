using AutoMapper;
using SparkSwim.GoodsService.Common.Mapping;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Discounts.Queries.GetDiscountsList;

public class DiscountLookUpDto : IMapWith<Discount>
{
    public Guid DiscountId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal DiscountValue { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Discount, DiscountLookUpDto>();
    }
}
