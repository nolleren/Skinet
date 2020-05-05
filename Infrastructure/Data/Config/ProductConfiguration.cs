using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(_ => _.Id).IsRequired();
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(100);
            builder.Property(_ => _.Description).IsRequired().HasMaxLength(180);
            builder.Property(_ => _.Price).HasColumnType("decimal(18,2)");
            builder.Property(_ => _.PictureUrl).IsRequired();
            builder.HasOne(_ => _.ProductBrand).WithMany()
                .HasForeignKey(_ => _.ProductBrandId);
            builder.HasOne(_ => _.ProductType).WithMany()
                .HasForeignKey(_ => _.ProductTypeId);
        }
    }
}