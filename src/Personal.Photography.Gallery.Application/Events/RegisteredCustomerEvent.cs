using Personal.Photography.Gallery.Core.Messages.CommonMessages.DomainEvents;

namespace Personal.Photography.Gallery.Application.Events
{
    public class RegisteredCustomerEvent : DomainEvent
    {
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cpf { get; private set; }

        public RegisteredCustomerEvent(Guid aggregateId, string nome, DateTime dataNascimento, string cpf) : base(aggregateId)
        {
            AggregateId = aggregateId;
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
        }
    }
}
