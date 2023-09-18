using Personal.Photography.Gallery.Domain.DTOs.ResponseDtos;

namespace Personal.Photography.Gallery.Domain.Interfaces.Queries
{
    public interface IClientQueries
    {
        Task<IEnumerable<ClientResponse>> GetClients();
        Task<ClientResponse> GetClient(Guid id);
    }
}
