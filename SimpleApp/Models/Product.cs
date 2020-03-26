using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace SimpleApp.Models
{
    public class Product : IEntityTypeConfiguration<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCTS").HasKey(e => e.Id).HasName("Guid");
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(100).IsRequired().HasColumnName("Name");
            builder.Property(e => e.Price).HasColumnType("DECIMAL").IsRequired().HasColumnName("Price");
        }
    }
}