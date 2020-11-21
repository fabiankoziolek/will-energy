using System.IO;
using MediatR;
using WillEnergy.Domain.Core.Documents;

namespace WillEnergy.Application.Forms.Commands
{
    public class SubmitForm : DocumentContract, IRequest<MemoryStream>
    {
    }
}
