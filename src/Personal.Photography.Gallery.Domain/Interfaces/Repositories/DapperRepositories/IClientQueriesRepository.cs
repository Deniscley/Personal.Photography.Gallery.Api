using Personal.Photography.Gallery.Domain.DTOs.ResponseDtos;
using Personal.Photography.Gallery.Domain.Entities;

namespace Personal.Photography.Gallery.Domain.Interfaces.Repositories.DapperRepositories
{
    public interface IClientQueriesRepository
    {
        Task InsertCustomer(Client client);
        //Task<IEnumerable<Client>> GetClientsAsync();
        Task<ClientResponse> GetClientAsync(Guid id);

    }
}
