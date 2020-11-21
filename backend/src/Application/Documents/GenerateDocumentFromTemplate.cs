using System.Collections.Generic;
using System.IO;
using MediatR;
using WillEnergy.Domain.Core.Documents;

namespace WillEnergy.Application.Documents
{
    public class GenerateDocumentFromTemplate : IRequest<MemoryStream>
    {
        public string DocumentTemplateName { get; }
        public IList<DocumentPositionKeyValue> DocumentPositionKeyValues { get; }

        public GenerateDocumentFromTemplate(string documentTemplateName, IList<DocumentPositionKeyValue> documentPositionKeyValues)
        {
            DocumentTemplateName = documentTemplateName;
            DocumentPositionKeyValues = documentPositionKeyValues;
        }
    }
}
