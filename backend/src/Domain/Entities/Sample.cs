using System;
using WillEnergy.Domain.Common.Auditability;
using WillEnergy.Domain.Common.RichObjects;
using WillEnergy.Domain.Enums;
using WillEnergy.Domain.Rules.Reservations;
using WillEnergy.Domain.ValueObjects.Identifiers;

namespace WillEnergy.Domain.Entities
{
    public class Sample : Entity, IAuditableEntity
    {
        public int DatabaseId { get; set; }

        public SampleId Id => new SampleId(DatabaseId);
        public DateTimeOffset Date { get; set; }
        public SampleType Type { get; set; }
        public UserId UserId { get; set; }
        public string Username { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }

        public Sample(DateTimeOffset date, SampleType type, UserId userId, string username)
        {
            Date = date;
            Type = type;
            UserId = userId;
            Username = username;
            CreatedAt = DateTimeOffset.UtcNow;
        }

        private Sample()
        {
        }

        public void Cancel()
        {
            CheckRule(new OnlyActiveSampleCanBeCancelledRule(Id, IsDeleted));

            IsDeleted = true;
            ModifiedAt = DateTimeOffset.UtcNow;
        }
    }
}
