using MediatR;

namespace WillEnergy.Application.Common.Bus
{
  public interface IQuery<out TResponse> : IRequest<TResponse>
  {
  }
}
