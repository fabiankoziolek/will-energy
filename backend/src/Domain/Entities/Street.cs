using System;
using WillEnergy.Domain.Common.RichObjects;

namespace WillEnergy.Domain.Entities
{
    public class Street : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? GasDateConnection { get; set; }
        public DateTimeOffset? HeatDateConnection { get; set; }
    }
}
