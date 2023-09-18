using Microsoft.AspNetCore.Mvc;
using Personal.Photography.Gallery.Application.Commands;
using Personal.Photography.Gallery.Core.Communication.Mediator;
using Personal.Photography.Gallery.Domain.Interfaces.Queries;
//using SerilogTimings;

namespace Personal.Photography.Gallery.Api.Controllers
{
    //[Authorize]
    [Route("api/client")]
    [ApiController]
    public class ClientController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IClientQueries _clientQueries;
        //private readonly ILogger<ClientController> _logger;

        public ClientController(
            IMediatorHandler mediatorHandler,
            IClientQueries clientQueries
            //ILogger<ClientController> logger
            )
        {
            _mediatorHandler = mediatorHandler;
            _clientQueries = clientQueries;
            //_logger = logger;
        }

        /// <summary>
        /// Obter lista de clientes.
        /// </summary>
        /// <returns>Retorna lista de clientes.</returns>
        [HttpGet("obter-todos")]
        public async Task<IActionResult> Get()
        {   
            //using (Operation.Time("Tempo para busca dos cliente."))
            //{
            //    _logger.LogInformation("Foi requisitado a busca dos clientes.");
                var response = await _clientQueries.GetClients();

                if (response.Any())
                {
                    return Ok(response);
                }

                return NotFound();
            //}
        }

        /// <summary>
        /// Obter cliente por id.
        /// </summary>
        /// <param name="id" example="123">Id do Cliente</param>
        /// <returns>Retorna cliente por id</returns>
        [HttpGet("obter-por-id/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _clientQueries.GetClient(id));
        }

        /// <summary>
        /// Registrar clientes.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Retorna comando de confirmação de registro do cliente.</returns>
        [HttpPost("inserir-clientes")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> Post()
        {
            var result = await _mediatorHandler
                .SendCommand(new RegisterClientCommand(Guid.NewGuid(), "Goku", DateTime.Now, "90319961048"));

            return CustomResponse(result);
        }

        /// <summary>
        /// Atualizar cliente por id.
        /// </summary>
        /// <param name="id" example="123"></param>
        [HttpPut("atualizar-clientes/{id:guid}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Remover cliente por id.
        /// </summary>
        /// <param name="id" example="123">Id of Client</param>
        /// <remarks>When deleting the client, it will be permanently removed from the base.</remarks>
        [HttpDelete("deletar-por-id/{id:guid}")]
        public void Delete(int id)
        {
        }
    }
}
