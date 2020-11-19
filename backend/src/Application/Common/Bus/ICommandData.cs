using MediatR;

namespace WillEnergy.Application.Common.Bus
{
  public interface ICommandData<out TResponse> : IRequest<TResponse>
  {
  }
}
