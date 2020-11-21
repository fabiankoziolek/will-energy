using System.Collections.Generic;
using System.IO;
using MediatR;
using WillEnergy.Domain.Core.Documents;

namespace WillEnergy.Application.Forms.Commands
{
    public class GenerateZipArchiveWithApplicationFiles : IRequest<MemoryStream>
    {
        public IList<string> DocumentTemplates { get; }
        public IList<DocumentPositionKeyValue> DocumentPositionsKeyValues { get; set; }
        public MemoryStream Stream { get; set; }
        public GenerateZipArchiveWithApplicationFiles(IList<string> documentTemplates, IList<DocumentPositionKeyValue> keyValues)
        {
            DocumentTemplates = documentTemplates;
            DocumentPositionsKeyValues = keyValues;
        }
    }
}
