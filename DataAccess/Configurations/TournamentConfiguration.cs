using DataAccess.TableClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.Property(t => t.Id).HasMaxLength(32);
            builder.Property(t => t.name).IsRequired();
            builder.Property(t => t.CategoryId).IsRequired();
        }
    }
}
