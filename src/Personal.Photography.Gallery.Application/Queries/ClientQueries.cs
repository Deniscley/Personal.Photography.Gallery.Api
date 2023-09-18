using Personal.Photography.Gallery.Domain.DTOs.ResponseDtos;
using Personal.Photography.Gallery.Domain.Interfaces.Queries;
using Personal.Photography.Gallery.Domain.Interfaces.Repositories.DapperRepositories;
using Personal.Photography.Gallery.Domain.Interfaces.Repositories.EFRepositories;

namespace Personal.Photography.Gallery.Application.Queries
{
    public class ClientQueries : IClientQueries
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientQueriesRepository _clientQueriesRepository;

        public ClientQueries(IClientRepository clientRepository, IClientQueriesRepository clientQueriesRepository)
        {
            _clientRepository = clientRepository;
            _clientQueriesRepository = clientQueriesRepository;
        }

        public async Task<ClientResponse> GetClient(Guid id)
        {
            var response = await _clientQueriesRepository.GetClientAsync(id);

            return response;
        }

        public async Task<IEnumerable<ClientResponse>> GetClients()
        {
            var response = await _clientRepository.GetClientsAsync();

            return response;
        }
    }
}
