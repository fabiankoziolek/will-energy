using System;
using System.Linq;
using System.Threading.Tasks;
using WillEnergy.Domain.Entities;
using WillEnergy.Domain.Enums;
using WillEnergy.Domain.ValueObjects.Identifiers;

namespace WillEnergy.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static readonly UserId UserId = new UserId("1EE9DFBA-6CB3-4974-8738-2C0BE711246C");

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Samples.Any())
            {
                var samples = new[]
                {
                    new Sample(DateTimeOffset.UtcNow, SampleType.Type1, UserId, "Rafał"),
                };

                await context.Samples.AddRangeAsync(samples);
                await context.SaveChangesAsync();
            }
        }
    }
}
