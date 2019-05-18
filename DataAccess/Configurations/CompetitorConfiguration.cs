using DataAccess.TableClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class CompetitorConfiguration : IEntityTypeConfiguration<Competitor>
    {
        public void Configure(EntityTypeBuilder<Competitor> builder)
        {
            builder.Property(c => c.Id).HasMaxLength(32);
            builder.Property(c => c.name).HasMaxLength(128).IsRequired();
            builder.Property(c => c.short_name).HasMaxLength(8);
            builder.Property(c => c.country_code).HasMaxLength(8);
        }
    }
}
