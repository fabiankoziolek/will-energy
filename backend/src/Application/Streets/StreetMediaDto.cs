using System;

namespace WillEnergy.Application.Streets
{
    public class StreetMediaDto
    {
        public int Id { get; set; }
        public bool HasGasConnection { get; set; }
        public bool HasHeatConnection { get; set; }
        public DateTimeOffset? GasDateConnection { get; set; }
        public DateTimeOffset? HeatDateConnection { get; set; }
    }
}
