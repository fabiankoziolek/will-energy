using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WillEnergy.Domain.Core.Documents;
using WillEnergy.Domain.Core.Documents.Parser;

namespace WillEnergy.Application.Documents.Handlers
{
    public class GenerateDocumentFromTemplateCommandHandler : IRequestHandler<GenerateDocumentFromTemplate, MemoryStream>
    {
        private readonly IDocumentParser _documentParser;

        public GenerateDocumentFromTemplateCommandHandler()
        {
            _documentParser = new DocumentParser();
        }

        public async Task<MemoryStream> Handle(GenerateDocumentFromTemplate request, CancellationToken cancellationToken)
        {
            var documentPath = Path.Combine(DocumentConsts.TemplatesFolder, request.DocumentTemplateName);

            var parsedDocument = await _documentParser.ParseDocument(request.DocumentPositionKeyValues, documentPath);

            parsedDocument.Position = 0;
            return parsedDocument;
        }
    }
}
