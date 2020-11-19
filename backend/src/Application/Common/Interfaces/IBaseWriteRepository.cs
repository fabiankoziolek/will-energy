using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace WillEnergy.Application.Common.Interfaces
{
    public interface IBaseWriteRepository
    {
        Task<IDbContextTransaction> BeginTransaction();
        Task SaveChanges();
    }
}
