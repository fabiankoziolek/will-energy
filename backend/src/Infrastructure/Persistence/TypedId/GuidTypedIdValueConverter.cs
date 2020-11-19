using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WillEnergy.Domain.Common.RichObjects;

namespace WillEnergy.Infrastructure.Persistence.TypedId
{
    public class GuidTypedIdValueConverter<TTypedIdValue> : ValueConverter<TTypedIdValue, Guid>
        where TTypedIdValue : GuidTypedId
    {
        public GuidTypedIdValueConverter(ConverterMappingHints mappingHints = null)
            : base(id => id.Value, value => Create(value), mappingHints)
        {
        }

        private static TTypedIdValue Create(Guid id) => Activator.CreateInstance(typeof(TTypedIdValue), id) as TTypedIdValue;
    }
}
