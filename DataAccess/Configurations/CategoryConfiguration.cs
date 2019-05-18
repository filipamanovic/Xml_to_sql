using DataAccess.TableClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Id).HasMaxLength(32);
            builder.Property(c => c.name).IsRequired();
            builder.Property(c => c.SportId).IsRequired();
        }
    }
}
