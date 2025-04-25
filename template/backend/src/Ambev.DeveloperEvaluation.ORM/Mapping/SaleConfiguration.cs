using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            // Primary Key
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            // Properties
            builder.Property(s => s.SaleNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.Date)
                .IsRequired()
                .HasColumnType("timestamp with time zone");

            builder.Property(s => s.Customer)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Branch)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Enum conversions
            builder.Property(s => s.Status)
                .HasConversion<string>()
                .HasMaxLength(20);

            // Relationships
            builder.HasMany(s => s.Items)
                .WithOne()
                .HasForeignKey("SaleId")
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(s => s.SaleNumber)
                .IsUnique();

            builder.HasIndex(s => s.Date);
            builder.HasIndex(s => s.Customer);
            builder.HasIndex(s => s.Branch);
        }
    }
}