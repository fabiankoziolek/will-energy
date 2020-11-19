using System.Threading.Tasks;

namespace WillEnergy.WebUI.Jobs.Common
{
    public interface IJob
    {
        Task Execute();
    }
}
