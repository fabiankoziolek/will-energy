using System.IO;
using MediatR;
using WillEnergy.Domain.Core.Documents;
using WillEnergy.Domain.Core.Forms;

namespace WillEnergy.Application.Forms.Commands
{
    public class SubmitForm : DocumentContract, IRequest<MemoryStream>
    {
    }
}
