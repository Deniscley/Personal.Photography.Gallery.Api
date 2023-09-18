using FluentValidation.Results;
using MediatR;
using Personal.Photography.Gallery.Application.Commands;
using Personal.Photography.Gallery.Domain.Entities;
using Personal.Photography.Gallery.Domain.Interfaces.Repositories.EFRepositories;
using Personal.Photography.Gallery.Core.Messages;

namespace Personal.Photography.Gallery.Application.CommandsHandler
{
    public class ClientCommandHandler : CommandHandler, 
        IRequestHandler<RegisterClientCommand, ValidationResult>
    {
        private readonly IClientRepository _clientRepository;
        public ClientCommandHandler(IClientRepository clientRepository) {
            _clientRepository = clientRepository;
        
        }
        public async Task<ValidationResult> Handle(RegisterClientCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValid()) return message.ValidationResult;

            var client = new Client(message.Id, message.Nome, message.DataNascimento, message.Cpf);

            var existingCustomer = await _clientRepository.GetByCpf(message.Cpf);

            if (existingCustomer != null)
            {
                AddError("Este CPF já está em uso.");
                return ValidationResult;
            }

            _clientRepository.InsertClients(client);

            //client.AddEvent(new RegisteredCustomerEvent(message.Id, message.Nome, message.DataNascimento, message.Cpf));

            return await PersistData(_clientRepository.UnitOfWork);
        }
    }
}
