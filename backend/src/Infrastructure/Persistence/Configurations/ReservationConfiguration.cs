using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WillEnergy.Domain.Entities;
using WillEnergy.Domain.Enums;

namespace WillEnergy.Infrastructure.Persistence.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> builder)
        {
            builder.Ignore(e => e.Id);
            builder.HasKey(e => e.DatabaseId);
            builder.Property(e => e.DatabaseId).HasColumnName("Id");

            builder.Property(x => x.Type)
                .HasConversion(v => v.ToString(), v => (SampleType)Enum.Parse(typeof(SampleType), v))
                .IsRequired().HasMaxLength(15);

            builder.Property(x => x.Username)
                .IsRequired().HasMaxLength(255);
        }
    }
}
