using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class SportConfiguration : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.Property(s => s.Id).HasMaxLength(32);
            builder.Property(s => s.name).IsRequired();
        }
    }
}
