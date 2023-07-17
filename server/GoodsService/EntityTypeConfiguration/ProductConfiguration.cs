using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Goods.EntityTypeConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(_ => _.ProductId);
        builder.Property(_ => _.Title).HasMaxLength(50).IsRequired();
        builder.Property(_ => _.Description).HasMaxLength(300);
        builder.Property(_ => _.Price).IsRequired();
        builder.HasMany(_ => _.ProductImages).WithOne(_ => _.Product).HasForeignKey(_ => _.ProductId);
        builder.HasOne(_ => _.ProductType).WithMany(_ => _.Products).HasForeignKey(_ => _.ProductTypeId);
    }   
}