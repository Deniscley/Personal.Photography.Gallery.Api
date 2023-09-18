using Moq;
using NSubstitute;
using Personal.Photography.Gallery.Application.Commands;
using Personal.Photography.Gallery.Application.CommandsHandler;
using Personal.Photography.Gallery.Domain.Interfaces.Repositories.EFRepositories;
using Personal.Photography.Gallery.FakeData.Commands;

namespace Personal.Photography.Gallery.Tests.CommandsHandler
{
    public class ClientCommandHandlerTest
    {
        private readonly IClientRepository _clientRepository;
        private readonly RegisterClientCommand _registerClientCommand;
        private readonly RegisterClientCommandFaker _registerClientCommandFaker;

        private readonly Mock<ClientCommandHandler> _clientCommandHandler;

        public ClientCommandHandlerTest()
        {
            _clientRepository = Substitute.For<IClientRepository>();
            _registerClientCommandFaker = new RegisterClientCommandFaker();

            _clientCommandHandler = new Mock<ClientCommandHandler>();

            _registerClientCommand = _registerClientCommandFaker.Generate();
        }

        //[Fact(DisplayName = "Cliente inserido com sucesso")]
        //[Trait("Categoria", "ClientCommandHandler Trait Testes")]
        //public async Task Client_InsertCustomer_Sucess()
        //{
        //    //Arranje
        //    var message = _registerClientCommand;
        //    var client = new Client(message.Id, message.Nome, message.DataNascimento);

        //    //Act
        //    _clientRepository.GetClientAsync(client.Id);

        //    _clientRepository.InsertCustomer(client);
        //}
    }
}
