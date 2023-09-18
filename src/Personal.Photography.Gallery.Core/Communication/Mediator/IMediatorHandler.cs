using Personal.Photography.Gallery.Core.Messages;
using FluentValidation.Results;
using Personal.Photography.Gallery.Core.Messages.CommonMessages.Notifications;

namespace Personal.Photography.Gallery.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T eventt) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}
