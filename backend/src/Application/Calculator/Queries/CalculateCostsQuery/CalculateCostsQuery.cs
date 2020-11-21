using WillEnergy.Application.Common.Bus;
using WillEnergy.Domain.Core.Documents;

namespace WillEnergy.Application.Calculator.Queries.CalculateCostsQuery
{
    public class CalculateCostsQuery : IQuery<CalculateCostsDto>
    {
        public int BuildingArea { get; }
        public HeatingType HeatingType { get; }

        public CalculateCostsQuery(int buildingArea, HeatingType heatingType)
        {
            BuildingArea = buildingArea;
            HeatingType = heatingType;
        }
    }
}
