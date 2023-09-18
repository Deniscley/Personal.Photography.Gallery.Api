using MediatR;
using Personal.Photography.Gallery.Application.Events;

namespace Personal.Photography.Gallery.Application.EventsHandlers
{
    public class ClientEventHandler : INotificationHandler<RegisteredCustomerEvent>
    {
        // Função para trabalhar com evento
        public Task Handle(RegisteredCustomerEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
