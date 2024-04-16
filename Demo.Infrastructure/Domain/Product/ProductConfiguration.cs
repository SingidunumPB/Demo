using Demo.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Infrastructure.Domain.Product;

public class ProductConfiguration : IEntityTypeConfiguration<Demo.Domain.Entities.Product>
{

    public void Configure(EntityTypeBuilder<Demo.Domain.Entities.Product> builder)
    {
        builder.ToTable("Products");
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property<Guid>("CompanyId");
        builder.HasIndex("CompanyId");
        builder.HasOne(b => b.Company)
            .WithMany(b => b.Products)
            .HasForeignKey("CompanyId")
            .IsRequired();
        builder.Property(b => b.Category)
            .IsRequired()
            .HasDefaultValue(Category.Tehnika)
            .HasConversion(p => p.Value,
                p => Category.FromValue(p));
    }
}
