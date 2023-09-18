using Personal.Photography.Gallery.Domain.DTOs.ResponseDtos;
using Personal.Photography.Gallery.Domain.Entities;
using Personal.Photography.Gallery.Core.Data;

namespace Personal.Photography.Gallery.Domain.Interfaces.Repositories.EFRepositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<ClientResponse> GetByCpf(string cpf);
        Task<IEnumerable<ClientResponse>> GetClientsAsync();
        void InsertClients(Client client);
    }
}
