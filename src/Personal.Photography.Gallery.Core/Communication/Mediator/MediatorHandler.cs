using FluentValidation.Results;
using MediatR;
using Personal.Photography.Gallery.Core.Messages;
using Personal.Photography.Gallery.Core.Messages.CommonMessages.Notifications;

namespace Personal.Photography.Gallery.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T eventt) where T : Event
        {
            await _mediator.Publish(eventt);
        }

        public async Task PublishNotification<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);
        }

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}
