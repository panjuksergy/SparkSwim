using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SparkSwim.OrderService.Models;

namespace SparkSwim.OrderService.EntityType
{
    public class OrderArticleConfiguration : IEntityTypeConfiguration<OrderArticle>
    {
        public void Configure(EntityTypeBuilder<OrderArticle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderArticles).HasForeignKey(x => x.OrderId).IsRequired();
            builder.Property(x => x.Price).HasPrecision(18, 2);
        }
    }
}
