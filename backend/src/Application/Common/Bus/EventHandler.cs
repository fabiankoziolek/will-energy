using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace WillEnergy.Application.Common.Bus
{
  public abstract class EventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IEvent
  {
    public abstract Task<Unit> Handle(TEvent request);

    public Task Handle(TEvent action, CancellationToken cancellationToken)
      => Handle(action);
  }
}
