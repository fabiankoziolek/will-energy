using WillEnergy.Application.Samples.Commands.ReadGasStreetConnectionsFromExcel;

namespace WillEnergy.WebUI.Controllers.Requests
{
    public class ImportGasConnectionsFromExcelRequest
    {
        public string GasFilePath { get; set; }
        public string HeatFilePath { get; set; }

        public ReadMediaConnectionsFromExcelCommand ToCommand(string gasFilePath, string heatFilePath)
        {
            return new ReadMediaConnectionsFromExcelCommand(gasFilePath, heatFilePath);
        }
    }
}
