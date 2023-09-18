using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Personal.Photography.Gallery.Domain.DTOs.ResponseDtos;
using Personal.Photography.Gallery.Domain.Entities;
using Personal.Photography.Gallery.Core.Data;
using Personal.Photography.Gallery.Domain.Interfaces.Repositories.EFRepositories;
using Personal.Photography.Gallery.Data.Context;

namespace Personal.Photography.Gallery.Data.Repositories.EFRepositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ClientRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<ClientResponse>> GetClientsAsync()
        {
            var response = await _context.Clients.AsNoTracking().ToListAsync();
            var clientsResponse = _mapper.Map<List<Client>, IEnumerable<ClientResponse>>(response);
            return clientsResponse;
        }

        public async Task<ClientResponse> GetByCpf(string cpf)
        {
            var response = await _context.Clients.FirstOrDefaultAsync(c => c.Cpf == cpf);
            var clientResponse = _mapper.Map<Client, ClientResponse>(response);
            return clientResponse;
        }

        public void InsertClients(Client client)
        {
            _context.Clients.Add(client);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
