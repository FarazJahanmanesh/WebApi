using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;
public class Product
{
    public long ID { get; set; }
    public string Name { get; set; }
    public DateTime ProductDate { get; set; }
    public string ManufacturePhone { get; set; }
    public string ManufactureEmail { get; set; }
    public bool IsAvailable { get; set; }
}

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.ID);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Property(p => p.ManufacturePhone).IsRequired().HasMaxLength(10);
        builder.Property(p => p.ManufactureEmail).IsRequired().HasMaxLength(200);

        builder.HasIndex(p => p.ProductDate).IsUnique();
        builder.HasIndex(p => p.ManufactureEmail).IsUnique();
    }
}