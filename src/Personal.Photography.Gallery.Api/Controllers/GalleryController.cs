using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personal.Photography.Gallery.Application.MongoDBServices;
using Personal.Photography.Gallery.Domain.Interfaces.MongoDBServices;

namespace Personal.Photography.Gallery.Api.Controllers
{
    //[Authorize]
    [Route("api/galeria")]
    [ApiController]
    public class GalleryController : Controller
    {
        private readonly IGalleryAppServices _galleryAppServices;

        public GalleryController(
            IGalleryAppServices galleryAppServices
        )
        {
            _galleryAppServices = galleryAppServices;
        }

        /// <summary>
        /// Obter lista de fotos.
        /// </summary>
        /// <returns>Retorna lista de fotografias.</returns>
        [HttpGet("obter-todos")]
        public async Task<IActionResult> GetAllPhotograph()
        {
            return Ok(await _galleryAppServices.GetAllPhotograph());
        }

        /// <summary>
        /// Registrar foto.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Retorna comando de confirmação de registro da foto.</returns>
        [HttpPost("inserir-foto")]
        public async Task<IActionResult> CreatePhotograph([FromBody] Photograph photograph)
        {
            if (photograph == null)
                return BadRequest();

            if (photograph.Base64Data == string.Empty)
            {
                ModelState.AddModelError("Name", "A fotografia não deve estar vazia");
            }

            await _galleryAppServices.InsertPhotograph(photograph);

            return Created("Created", true);
        }

        /// <summary>
        /// Atualizar fotografia por id.
        /// </summary>
        /// <param name="id" example="123"></param>
        [HttpPut("atualizar-foto/{id}")]
        public async Task<IActionResult> UpdatePhotograph(Photograph photograph, string id)
        {
            if (photograph == null)
                return BadRequest();

            if (photograph.Base64Data == string.Empty)
            {
                ModelState.AddModelError("Name", "A fotografia não deve estar vazia");
            }

            photograph.Id = id;
            await _galleryAppServices.UpdatePhotograph(photograph);

            return Created("Created", true);
        }

        /// <summary>
        /// Remover foto por id.
        /// </summary>
        /// <param name="id" example="123">Id da foto</param>
        /// <remarks>Ao excluir a foto, ela será removido permanentemente da base.</remarks>
        [HttpDelete("deletar-por-id/{id}")]
        public async Task<IActionResult> DeletePhotograph(string id)
        {
            await _galleryAppServices.DeletePhotograph(id);

            return NoContent(); //success
        }
    }
}
