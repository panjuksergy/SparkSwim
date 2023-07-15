using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Goods.EntityTypeConfiguration;

public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.HasKey(_ => _.ProductTypeId);
    }
}