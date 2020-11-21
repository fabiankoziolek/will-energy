using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WillEnergy.Domain.Core.Documents;
using WillEnergy.Domain.Core.Documents.Extractor;
using WillEnergy.Domain.Core.Forms;

namespace WillEnergy.Application.Forms.Commands.Handlers
{
    public class SubmitFormCommandHandler : IRequestHandler<SubmitForm, MemoryStream>
    {
        private readonly IMediator _mediator;

        public SubmitFormCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<MemoryStream> Handle(SubmitForm request, CancellationToken cancellationToken)
        {
            var documentsToGenerate = DetermineRequiredDocuments(request);
            var documentPositionKeyValues = FormKeyValueParser.ExtractKeyValues(new FormInput(request));

            var stream = await _mediator.Send(new GenerateZipArchiveWithApplicationFiles(documentsToGenerate, documentPositionKeyValues));
            return stream;
        }

        private static IList<string> DetermineRequiredDocuments(SubmitForm requestType)
        {
            var documentsToGenerate = new List<string>()
            {
                DocumentConsts.Doc1,
                DocumentConsts.Doc2,
                DocumentConsts.Doc6,
            };

            if (requestType.LawParticipants.Any())
            {
                documentsToGenerate.Add(DocumentConsts.Doc3);
            }
            else if (requestType.InvestorType != EInvestorType.PrivateIndividual)
            {
                documentsToGenerate.Add(DocumentConsts.Doc4);
                documentsToGenerate.Add(DocumentConsts.Doc5);
            }

            return documentsToGenerate;
        }
    }
}
