using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WillEnergy.Application.Documents;

namespace WillEnergy.Application.Forms.Commands.Handlers
{
    public class GenerateZipArchiveWithApplicationFilesCommandHandler : IRequestHandler<GenerateZipArchiveWithApplicationFiles, MemoryStream>
    {
        private readonly IMediator _mediator;
        public GenerateZipArchiveWithApplicationFilesCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<MemoryStream> Handle(GenerateZipArchiveWithApplicationFiles request, CancellationToken cancellationToken)
        {
            var zipStream = new MemoryStream();
            using (var zip = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                foreach (var document in request.DocumentTemplates)
                {
                    var entry = zip.CreateEntry(document);
                    await using var generatedForm = await _mediator.Send(new GenerateDocumentFromTemplate(document, request.DocumentPositionsKeyValues));
                    await using var entryStream = entry.Open();
                    await generatedForm.CopyToAsync(entryStream);
                }

                zip.Dispose();
            }

            zipStream.Position = 0;
            return zipStream;
        }
    }
}
