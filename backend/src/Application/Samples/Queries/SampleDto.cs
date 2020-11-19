using System;
using WillEnergy.Application.Common.Mappings;
using WillEnergy.Domain.Entities;

namespace WillEnergy.Application.Samples.Queries
{
    public class SampleDto : IMapFrom<Sample>
    {
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Type { get; set; }
    }
}
