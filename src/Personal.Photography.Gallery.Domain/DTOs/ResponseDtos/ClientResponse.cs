using System.ComponentModel.DataAnnotations;

namespace Personal.Photography.Gallery.Domain.DTOs.ResponseDtos
{
    /// <summary>
    /// Objeto utilizado para retornar dados do cliente.
    /// </summary>
    public class ClientResponse : ICloneable
    {
        /// <summary>
        /// Id do cliente.
        /// </summary>
        /// <example>123</example>
        [Required]
        public Guid Id { get; private set; }

        /// <summary>
        /// Nome do cliente.
        /// </summary>
        /// <example>João</example>
        public string Nome { get; private set; }

        /// <summary>
        /// Data de nascimento.
        /// </summary>
        /// <example>1980-01-01</example>
        public DateTime DataNascimento { get; private set; }

        /// <summary>
        /// Cpf do cliente.
        /// </summary>
        /// <example>19873648725</example>
        public string Cpf { get; private set; }

        public object Clone()
        {
            var client = (ClientResponse)MemberwiseClone();
            return client;
        }

        public ClientResponse TypedClone()
        {
            return (ClientResponse)Clone();
        }
    }
}
