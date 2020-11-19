using NUnit.Framework;
using WillEnergy.Domain.ValueObjects.Identifiers;

namespace WillEnergy.Domain.UnitTests
{
    public abstract class DomainTestBase
    {
        protected static readonly UserId TestUserId = UserId.Generate();

        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
