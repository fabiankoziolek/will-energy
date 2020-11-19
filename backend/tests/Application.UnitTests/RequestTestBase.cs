using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NUnit.Framework;
using WillEnergy.Application.Common.Mappings;
using WillEnergy.Domain.ValueObjects.Identifiers;
using WillEnergy.Infrastructure.Persistence;
using WillEnergy.Infrastructure.Persistence.TypedId;

namespace WillEnergy.Application.UnitTests
{
    public abstract class RequestTestBase
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        protected static UserId TestUserId()
        {
            return ApplicationDbContextSeed.UserId;
        }

        protected static async Task<ApplicationDbContext> Context()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
            builder.UseSqlite("DataSource=:memory:");
            var dbContext = new ApplicationDbContext(builder.Options);
            await dbContext.Database.OpenConnectionAsync();
            await dbContext.Database.EnsureCreatedAsync();
            return dbContext;
        }

        protected static async Task<ApplicationDbContext> InitializedContext()
        {
            var context = await Context();
            await ApplicationDbContextSeed.SeedSampleDataAsync(context);
            return context;
        }

        protected static IMapper Mapper()
        {
            var mapperConfiguration = new MapperConfiguration(configuration => { configuration.AddProfile(new MappingProfile()); });
            return mapperConfiguration.CreateMapper();
        }
    }
}
