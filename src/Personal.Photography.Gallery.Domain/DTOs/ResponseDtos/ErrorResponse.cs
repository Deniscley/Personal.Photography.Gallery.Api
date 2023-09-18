namespace Personal.Photography.Gallery.Domain.DTOs.ResponseDtos
{
    public class ErrorResponse
    {
        public string Id { get; private set; }
        public string RequestId { get; private set; }
        public DateTime Data { get; private set; }
        public string Mensagem { get; private set; }

        public ErrorResponse(string id, string requestId)
        {
            Id = id;
            RequestId = requestId;
            Data = DateTime.Now;
            Mensagem = "Erro inesperado.";
        }
    }
}
