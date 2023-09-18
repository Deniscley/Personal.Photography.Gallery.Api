using Personal.Photography.Gallery.Domain.DTOs.ResponseDtos;
using Personal.Photography.Gallery.Domain.Entities;

namespace Personal.Photography.Gallery.Domain.Interfaces.Repositories.MongoDBRepositories
{
    public interface IClientMongoRepository
    {
        Task<ClientResponse> GetByCpf(string cpf);
        Task<IEnumerable<ClientResponse>> GetClientsAsync();
        void InsertClients(Client client);
    }
}
