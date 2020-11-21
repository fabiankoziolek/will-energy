using WillEnergy.Application.Common.Bus;

namespace WillEnergy.Application.Streets.Queries
{
    public class StreetMediaQuery : IQuery<StreetMediaDto>
    {
        public string StreetName { get; }

        public StreetMediaQuery(string streetName)
        {
            StreetName = streetName;
        }
    }
}
