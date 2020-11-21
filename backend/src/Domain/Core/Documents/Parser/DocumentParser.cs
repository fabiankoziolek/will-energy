using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace WillEnergy.Domain.Core.Documents.Parser
{
    public class DocumentParser : IDocumentParser
    {
        public async Task<MemoryStream> ParseDocument(IList<DocumentPositionKeyValue> keyValues, string documentPath)
        {
            var documentTemplate = new MemoryStream();

            await using (var file = File.Open(documentPath, FileMode.OpenOrCreate))
            {
                await file.CopyToAsync(documentTemplate);
            }

            documentTemplate.Position = 0;
            var parsedDocument = new MemoryStream();

            using (var wordDocument = DocX.Load(documentTemplate))
            {
                foreach (var keyValue in keyValues)
                {
                    wordDocument.ReplaceText(keyValue.Key, keyValue.Value);
                }

                wordDocument.SaveAs(parsedDocument);
            }

            parsedDocument.Position = 0;
            return parsedDocument;
        }
    }
}
