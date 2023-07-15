using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Goods.EntityTypeConfiguration;

public class ImageConfiguration : IEntityTypeConfiguration<ImagesProductModel>
{
    public void Configure(EntityTypeBuilder<ImagesProductModel> builder)
    {
        builder.HasKey(_ => _.ProductId);
    }
}