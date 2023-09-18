using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Personal.Photography.Gallery.Data.Context;
using Personal.Photography.Gallery.Data.MappingsProfile;
using Personal.Photography.Gallery.Data.Repositories.EFRepositories;
using Personal.Photography.Gallery.Domain.DTOs.ResponseDtos;
using Personal.Photography.Gallery.Domain.Entities;
using Personal.Photography.Gallery.Domain.Interfaces.Repositories.EFRepositories;
using Personal.Photography.Gallery.FakeData.DTOs;
using Personal.Photography.Gallery.FakeData.Entities;
using Xunit;

namespace Personal.Photography.Gallery.Tests.Repositories.EFRepositories
{
    public class ClientRepositoryTest : IDisposable
    {
        private readonly IClientRepository _repository;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly Client _client;
        private readonly ClientResponse _clientResponse;
        private ClientFaker _clientFaker;
        private ClientResponseFaker _clientResponseFaker;


        public ClientRepositoryTest()
        {
            var optionBuider = new DbContextOptionsBuilder<DataContext>();
            optionBuider.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _mapper = new MapperConfiguration(p => p.AddProfile<ClientMappingProfile>()).CreateMapper();

            _context = new DataContext(optionBuider.Options);
            _repository = new ClientRepository(_context, _mapper);

            _clientFaker = new ClientFaker();
            _client = _clientFaker.Generate();
        }

        private async Task<List<Client>> InsertRecords()
        {
            var clients = _clientFaker.Generate(100);

            foreach (var client in clients)
            {
                client.InsertId(Guid.NewGuid());
                await _context.Clients.AddAsync(client);
            }

            await _context.SaveChangesAsync();

            return clients;
        }

        [Fact(DisplayName = "Clientes com retorno")]
        [Trait("Categoria", "ClientRepository Trait Testes")]
        public async Task Client_GetClientsAsync_WithReturn()
        {
            //Arranje
            var records = await InsertRecords();

            //Act
            var result = await _repository.GetClientsAsync();
            var control = _mapper.Map<List<Client>, IEnumerable<ClientResponse>>(records);

            //Assert
            var total = control.Count();
            result.Should().HaveCount(total);
        }

        [Fact(DisplayName = "Clientes vazio")]
        [Trait("Categoria", "ClientRepository Trait Testes")]
        public async Task Client_GetClientsAsync_Empty()
        {
            //Act
            var result = await _repository.GetClientsAsync();

            // Assert
            result.Should().HaveCount(0);
        }

        [Fact(DisplayName = "Clientes encontrados")]
        [Trait("Categoria", "ClientRepository Trait Testes")]
        public async Task Client_GetByCpf_Found()
        {
            //Arranje
            var records = await InsertRecords();

            //Act
            var result = await _repository.GetByCpf(records.First().Cpf);
            var control = _mapper.Map<List<Client>, List<ClientResponse>>(records);

            //Assert
            result.Should().BeEquivalentTo(control.First());
        }

        [Fact(DisplayName = "Clientes não encontrados")]
        [Trait("Categoria", "ClientRepository Trait Testes")]
        public async Task Client_GetByCpf_NotFound()
        {
            //Act
            var result = await _repository.GetByCpf("23489647821");

            // Assert
            result.Should().BeNull();
        }

        //[Fact(DisplayName = "Cliente inserido com sucesso")]
        //[Trait("Categoria", "ClientRepository Trait Testes")]
        //public void InsertCustomer_Sucess()
        //{
        //    Act
        //    var result = _repository.InsertCustomer(_client);
        //}

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
