using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Data.Models.Mapping
{
    public class BrandMapping : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(x => x.BrandId);

            builder.Property(x => x.BrandIdentifier).IsRequired();
            builder.Property(x => x.Title).IsRequired();

            builder.HasIndex(x => x.BrandIdentifier).IsUnique();

            // timestamp (concurrency token)
            builder.Property(x => x.Timestamp).IsRowVersion();

            // shadow property
            builder.Property<DateTime>("LastUpdated");

            builder.HasAlternateKey(x => x.BrandIdentifier).HasName("AlternateKey_BrandIdentifier");
        }
    }
}