using AutoMapper;
using SparkSwim.GoodsService.Common.Mapping;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Discounts.Queries.GetDiscount;

public class DiscountVm : IMapWith<Discount>
{
    public Guid DiscountId { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal DiscountValue { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Discount, DiscountVm>();
    }
}