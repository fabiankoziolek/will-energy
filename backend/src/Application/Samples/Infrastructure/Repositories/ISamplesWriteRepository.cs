using System.Threading.Tasks;
using WillEnergy.Application.Common.Interfaces;
using WillEnergy.Domain.Entities;
using WillEnergy.Domain.ValueObjects.Identifiers;

namespace WillEnergy.Application.Samples.Infrastructure.Repositories
{
    public interface ISamplesWriteRepository : IBaseWriteRepository
    {
        Task<Sample> Find(SampleId id);
    }
}
