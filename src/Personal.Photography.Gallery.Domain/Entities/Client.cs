using Personal.Photography.Gallery.Core.Data;
using Personal.Photography.Gallery.Core.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace Personal.Photography.Gallery.Domain.Entities
{
    public class Client : Entity, IAggregateRoot
    {
        [Required]
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public string Cpf { get; private set; }

        public Client()
        {
        }

        public Client(Guid id, string nome, DateTime dataNascimento, string cpf)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;

            Validate();
        }

        public void InsertId( Guid id )
        {
            Id = id;
        }

        public void Validate()
        {
            Validations.ValidateIfEmpty(Nome, "O campo Nome do cliente não pode estar vazio");
            Validations.ValidateIfEmpty(Cpf, "O campo Cpf do cliente não pode estar vazio");
        }
    }
}
