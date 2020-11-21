using System.Threading.Tasks;
using WillEnergy.Domain.Entities;

namespace WillEnergy.Application.Samples.Infrastructure.Repositories
{
    public interface IStreetReadRepository
    {
        Task<Street> FindByName(string name);
    }
}
