using ExcelDataReader;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WillEnergy.Application.Common.Bus;
using WillEnergy.Application.Samples.Infrastructure.Repositories;
using WillEnergy.Domain.Entities;

namespace WillEnergy.Application.Samples.Commands.ReadGasStreetConnectionsFromExcel
{
    public class ReadMediaConnectionsFromExcelCommandHandler : CommandHandler<ReadMediaConnectionsFromExcelCommand>
    {
        private readonly IStreetsWriteRepository _writeRepository;

        public ReadMediaConnectionsFromExcelCommandHandler(
            IStreetsWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public override async Task<Unit> Handle(ReadMediaConnectionsFromExcelCommand command)
        {
            var gasConnections = ReadConnections(command.GasFilePath);
            var heatConnections = ReadConnections(command.HeatFilePath);

            var list = MergeConnections(gasConnections, heatConnections);

            await _writeRepository.SaveStreets(list);

            return Unit.Value;
        }

        private List<Street> MergeConnections(
            Dictionary<string, DateTimeOffset> gasConnections,
            Dictionary<string, DateTimeOffset> heatConnections)
        {
            var list = new List<Street>();
            foreach (var gasConnection in gasConnections)
            {
                var streetName = gasConnection.Key;
                var isOnHeatList = heatConnections.ContainsKey(streetName);

                var street = new Street
                {
                    Name = streetName,
                    GasDateConnection = gasConnection.Value,
                };
                if (isOnHeatList)
                {
                    street.HeatDateConnection = heatConnections[streetName];
                    heatConnections.Remove(streetName);
                }

                list.Add(street);
            }

            foreach (var heatConnection in heatConnections)
            {
                var streetName = heatConnection.Key;

                var street = new Street
                {
                    Name = streetName,
                    HeatDateConnection = heatConnection.Value,
                };

                list.Add(street);
            }

            return list;
        }

        private Dictionary<string, DateTimeOffset> ReadConnections(string gasFilePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using var fileStream = File.Open(gasFilePath, FileMode.Open, FileAccess.Read);
            using var fileReader = ExcelReaderFactory.CreateReader(fileStream);

            var connections = new Dictionary<string, DateTimeOffset>();
            var rowIdx = 1;
            while (fileReader.Read())
            {
                if (rowIdx == 1)
                {
                    rowIdx++;
                    continue;
                }

                var name = fileReader.GetString(1);
                if (string.IsNullOrEmpty(name))
                {
                    continue;
                }

                connections.Add(name.Trim(), default);
            }

            // read the second sheet - streets to be connected
            fileReader.NextResult();

            // write information about future connections
            rowIdx = 0;
            while (fileReader.Read())
            {
                if (rowIdx == 0)
                {
                    rowIdx++;
                    continue;
                }

                var name = fileReader.GetString(1);
                if (string.IsNullOrEmpty(name))
                {
                    continue;
                }

                var yearString = fileReader.GetString(2);
                var year = int.Parse(yearString);

                if (!connections.ContainsKey(name))
                {
                    connections.Add(name.Trim(), default(DateTimeOffset).AddYears(year - 1));
                }
            }

            return connections;
        }
    }
}
