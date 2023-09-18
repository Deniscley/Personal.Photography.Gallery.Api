using FluentValidation;
using Personal.Photography.Gallery.Core.Messages;

namespace Personal.Photography.Gallery.Application.Commands
{
    /// <summary>
    /// Comando utilizado para cadastro de clientes.
    /// </summary>
    public class RegisterClientCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cpf { get; private set; }

        public RegisterClientCommand(Guid id, string nome, DateTime dataNascimento, string cpf)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;

        }

        public override bool EhValid()
        {
            ValidationResult = new RegisterClientValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RegisterClientValidation : AbstractValidator<RegisterClientCommand>
        {
            public RegisterClientValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do cliente inválido");

                RuleFor(c => c.Nome)
                    .NotEmpty()
                    .WithMessage("O nome do cliente não foi informado");
            }
        }
    }
}
