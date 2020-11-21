using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace WillEnergy.Domain.Core.Documents.Parser
{
    public interface IDocumentParser
    {
        Task<MemoryStream> ParseDocument(IList<DocumentPositionKeyValue> keyValues, string documentPath);
    }
}
