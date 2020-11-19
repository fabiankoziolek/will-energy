using MediatR;

namespace WillEnergy.Application.Common.Bus
{
  public interface ICommand : IRequest<Unit>
  {
  }
}
