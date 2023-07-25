using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SparkSwim.OrderService.Models;

namespace SparkSwim.OrderService.EntityType
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderId);
            builder.HasMany(x => x.OrderArticles).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
            builder.Property(x => x.FirstName).HasMaxLength(20);
            builder.Property(x => x.SecondName).HasMaxLength(20);
            builder.Property(x => x.Address).HasMaxLength(120);
            builder.Property(x => x.Phone).HasMaxLength(16);
            builder.Property(x => x.Email).HasMaxLength(32);
        }
    }
}
