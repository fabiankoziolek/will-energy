using System.Collections.Generic;
using System.Threading.Tasks;
using WillEnergy.Application.Common.Interfaces;
using WillEnergy.Domain.Entities;

namespace WillEnergy.Application.Samples.Infrastructure.Repositories
{
    public interface IStreetsWriteRepository : IBaseWriteRepository
    {
        Task SaveStreets(IList<Street> streets);
    }
}
