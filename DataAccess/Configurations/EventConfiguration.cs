using DataAccess.TableClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Id).HasMaxLength(32);
            builder.Property(e => e.TournamentId).IsRequired().HasMaxLength(32);
            builder.Property(e => e.id_competitor_guest).IsRequired().HasMaxLength(32);
            builder.Property(e => e.id_competitor_host).IsRequired().HasMaxLength(32);
            builder.Property(e => e.utc_scheduled).IsRequired();
        }
    }
}
