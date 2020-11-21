using System;
using System.Collections.Generic;

namespace WillEnergy.Application.Calculator.Queries
{
    public class CalculateCostsDto
    {
        public double InstallationCost { get; set; }
        public double MonthlyUsageCost { get; set; }
        public IList<ReportHeatingType> Reports { get; set; }
    }

    public class ReportHeatingType
    {
        public string Type { get; set; }
        public IList<HeatingCostRecord> CostRecords { get; set; }
    }

    public class HeatingCostRecord
    {
        public DateTimeOffset Date { get; set; }
        public double Cost { get; set; }
    }
}
