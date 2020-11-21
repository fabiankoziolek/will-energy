using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WillEnergy.Application.Common.Bus;
using WillEnergy.Application.Common.Exceptions;
using WillEnergy.Domain.Core.Documents;

namespace WillEnergy.Application.Calculator.Queries.CalculateCostsQuery
{
    public class CalculateCostsQueryHandler : QueryHandler<CalculateCostsQuery, CalculateCostsDto>
    {
        public override Task<CalculateCostsDto> Handle(CalculateCostsQuery request)
        {
            var installationCostForNetworkNaturalGas = InstallationCostForNetworkNaturalGas(request.BuildingArea);
            var monthlyCostForNetworkNaturalGas = MonthlyCostForNetworkNaturalGas(request.BuildingArea);
            var installationCostForLiquefiedNaturalGas = InstallationCostForLiquefiedNaturalGas(request.BuildingArea);
            var monthlyCostForLiquefiedNaturalGas = MonthlyCostForLiquefiedNaturalGas(request.BuildingArea);
            var installationCostForBiomass = InstallationCostForBiomass(request.BuildingArea);
            var monthlyCostForBiomass = MonthlyCostForBiomass(request.BuildingArea);
            var installationCostForElectricity = InstallationCostForElectricity(request.BuildingArea);
            var monthlyCostForElectricity = MonthlyCostForElectricity(request.BuildingArea);
            var installationCostForNetworkHeat = InstallationCostForNetworkHeat();
            var monthlyCostForNetworkHeat = MonthlyCostForNetworkHeat(request.BuildingArea);
            var costs = new CalculateCostsDto();
            switch (request.HeatingType)
            {
                case HeatingType.NetworkNaturalGas:
                    costs.InstallationCost = installationCostForNetworkNaturalGas;
                    costs.MonthlyUsageCost = monthlyCostForNetworkNaturalGas;
                    break;
                case HeatingType.LiquefiedNaturalGas:
                    costs.InstallationCost = installationCostForLiquefiedNaturalGas;
                    costs.MonthlyUsageCost = monthlyCostForLiquefiedNaturalGas;
                    break;
                case HeatingType.Biomass:
                    costs.InstallationCost = installationCostForBiomass;
                    costs.MonthlyUsageCost = monthlyCostForBiomass;
                    break;
                case HeatingType.Electricity:
                    costs.InstallationCost = installationCostForElectricity;
                    costs.MonthlyUsageCost = monthlyCostForElectricity;
                    break;
                case HeatingType.NetworkHeat:
                    costs.InstallationCost = installationCostForNetworkHeat;
                    costs.MonthlyUsageCost = monthlyCostForNetworkHeat;
                    break;
                default:
                    throw new InternalServerErrorException();
            }

            costs.Reports = new List<ReportHeatingType>
            {
                new ReportHeatingType
                {
                    Type = HeatingType.NetworkNaturalGas.ToString(),
                    CostRecords = PrepareReports(installationCostForNetworkNaturalGas, monthlyCostForNetworkNaturalGas),
                },
                new ReportHeatingType
                {
                    Type = HeatingType.LiquefiedNaturalGas.ToString(),
                    CostRecords = PrepareReports(installationCostForLiquefiedNaturalGas, monthlyCostForLiquefiedNaturalGas),
                },
                new ReportHeatingType
                {
                    Type = HeatingType.Biomass.ToString(),
                    CostRecords = PrepareReports(installationCostForBiomass, monthlyCostForBiomass),
                },
                new ReportHeatingType
                {
                    Type = HeatingType.Electricity.ToString(),
                    CostRecords = PrepareReports(installationCostForElectricity, monthlyCostForElectricity),
                },
                new ReportHeatingType
                {
                    Type = HeatingType.NetworkHeat.ToString(),
                    CostRecords = PrepareReports(installationCostForNetworkHeat, monthlyCostForNetworkHeat),
                },
            };

            return Task.FromResult(costs);
        }

        private static IList<HeatingCostRecord> PrepareReports(int installationCost, int monthlyCost)
        {
            var startingValue = installationCost + monthlyCost;
            var now = DateTimeOffset.UtcNow;
            var records = new List<HeatingCostRecord>();
            for (var i = 0; i < 10 * 12; i++)
            {
                records.Add(new HeatingCostRecord { Date = now.AddDays(i), Cost = startingValue + i * monthlyCost });
            }

            return records;
        }

        private static int MonthlyCostForNetworkNaturalGas(int area)
        {
            return SelectCostPerArea(area, (3000 + 3500) / 2, (3500 + 4800) / 2, (4800 + 7000) / 2) / 12;
        }

        private static int InstallationCostForNetworkNaturalGas(int area)
        {
            return (1500 + 2000) / 2 + (800 + 1500) / 2 + (300 + 8000) / 2 + (100 + 200) / 2 + (2000 + 2500) / 2 + 1000 +
                   SelectCostPerArea(area, 10000, 15000, 22000) + (6000 + 12000) / 2;
        }

        private static int MonthlyCostForLiquefiedNaturalGas(int area)
        {
            return SelectCostPerArea(area, (3500 + 4000) / 2, (4000 + 6000) / 2, (6000 + 13000) / 2) / 12;
        }

        private static int InstallationCostForLiquefiedNaturalGas(int area)
        {
            return (1500 + 2000) / 2 + (7500 + 8000) / 2 + 500 + SelectCostPerArea(area, 12000, 17000, 20000) + (4000 + 8000) / 2;
        }

        private static int InstallationCostForBiomass(int area)
        {
            return SelectCostPerArea(area, 14000, 16000, 20000) + (4500 + 16000) / 2;
        }

        private static int MonthlyCostForBiomass(int area)
        {
            return SelectCostPerArea(area, (3500 + 4000) / 2, (4000 + 5000) / 2, (5000 + 8000) / 2) / 12;
        }

        private static int InstallationCostForElectricity(int area)
        {
            return SelectCostPerArea(area, 10000, 12000, 15500) + (2500 + 14000) / 2;
        }

        private static int MonthlyCostForElectricity(int area)
        {
            return SelectCostPerArea(area, (5000 + 6000) / 2, (6000 + 10000) / 2, (10000 + 15000) / 2) / 12;
        }

        private static int MonthlyCostForNetworkHeat(int area)
        {
            return SelectCostPerArea(area, (4000 + 4500) / 2, (4500 + 6000) / 2, (6000 + 15000) / 2) / 12;
        }

        private static int InstallationCostForNetworkHeat()
        {
            return (14000 + 17000) / 2;
        }

        private static int SelectCostPerArea(int area, int low, int mid, int high)
        {
            if (area < 100)
            {
                return low;
            }

            if (area > 100 && area < 200)
            {
                return mid;
            }

            return high;
        }
    }
}
