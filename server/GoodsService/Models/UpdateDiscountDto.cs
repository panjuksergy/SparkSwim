using AutoMapper;
using SparkSwim.GoodsService.Discounts.Commands.UpdateDiscount;

namespace SparkSwim.GoodsService.Goods.Models;

public class UpdateDiscountDto
{
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public decimal DiscountValue { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateProductDto, UpdateDiscountCommand>();
    }
}