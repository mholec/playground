using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Data.Models.Mapping
{
    public class CategoryDetailMapping : IEntityTypeConfiguration<CategoryDetail>
    {
        public void Configure(EntityTypeBuilder<CategoryDetail> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.CategoryId);

            builder.Property(x => x.Url).HasColumnType("varchar(200)");

            builder.HasOne(x => x.Category).WithOne(x => x.CategoryDetail).HasForeignKey<CategoryDetail>(x => x.CategoryId);
        }
    }
}
