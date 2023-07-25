using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Goods.EntityTypeConfiguration;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.HasKey(_ => _.DiscountId);
        builder.HasMany(_ => _.Products).WithOne(_ => _.Discount).OnDelete(DeleteBehavior.SetNull).HasForeignKey(_ => _.ProductId);
    }
}