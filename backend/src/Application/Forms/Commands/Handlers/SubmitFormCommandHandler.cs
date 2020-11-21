using System;
using System.Collections.Generic;
using System.IO;
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
            // TODO: determine document types?

            return new List<string>()
            {
                DocumentConsts.Doc1,
                DocumentConsts.Doc2,
                DocumentConsts.Doc3,
                DocumentConsts.Doc4,
                DocumentConsts.Doc5,
                DocumentConsts.Doc6,
            };
        }
    }
}
