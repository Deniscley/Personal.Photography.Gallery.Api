namespace Personal.Photography.Gallery.Domain.DTOs.RequestDtos
{
    /// <summary>
    /// Objeto utilizado para inserir novo cliente.
    /// </summary>
    public class ClientRequest
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public string Cpf { get; private set; }
    }
}
