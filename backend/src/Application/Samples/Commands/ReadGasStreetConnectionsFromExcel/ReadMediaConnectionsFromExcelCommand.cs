using WillEnergy.Application.Common.Bus;

namespace WillEnergy.Application.Samples.Commands.ReadGasStreetConnectionsFromExcel
{
    public class ReadMediaConnectionsFromExcelCommand : ICommand
    {
        public string GasFilePath { get; set; }
        public string HeatFilePath { get; set; }

        public ReadMediaConnectionsFromExcelCommand(string gasFilePath, string heatFilePath)
        {
            GasFilePath = gasFilePath;
            HeatFilePath = heatFilePath;
        }
    }
}
