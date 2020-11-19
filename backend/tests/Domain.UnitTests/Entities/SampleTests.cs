using System;
using FluentAssertions;
using NUnit.Framework;
using WillEnergy.Domain.Entities;
using WillEnergy.Domain.Enums;
using WillEnergy.Domain.Exceptions;
using WillEnergy.Domain.ValueObjects.Identifiers;

namespace WillEnergy.Domain.UnitTests.Entities
{
    public class SampleTests : DomainTestBase
    {
        [Test]
        public void ShouldAllowToCancel()
        {
            var entity = new Sample(DateTimeOffset.UtcNow, SampleType.Type1,  UserId.Generate(), "John Doe");

            entity.Cancel();

            entity.IsDeleted.Should().BeTrue();
            entity.ModifiedAt.Should().NotBeNull();
        }

        [Test]
        public void ShouldThrowExceptionWhenAlreadyCancelled()
        {
            var entity = new Sample(DateTimeOffset.UtcNow, SampleType.Type1, UserId.Generate(), "John Doe");
            entity.Cancel();

            entity.Invoking(x => x.Cancel()).Should()
                .Throw<DomainException>()
                .WithMessage("Sample is already cancelled. Entity Sample(key=0).");
        }
    }
}
