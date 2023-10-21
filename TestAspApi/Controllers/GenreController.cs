using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAspApi.DTOs;
using TestAspApi.Services.Interface;

namespace TestAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenresService _genresService;

        public GenreController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet]
        [Route("list-genre")]
        public async Task<IActionResult> GetGenres() 
        { 
            var reponse = await _genresService.GetAllAsync();

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpGet]
        [Route("{id:int}/get")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var reponse = await _genresService.GetOneGenreAsync(id);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpGet]
        [Route("{id:int}/get-with-livres")]
        public async Task<IActionResult> GetGenreWithLivres(int id)
        {
            var reponse = await _genresService.GetGenreWithLivresAsync(id);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpPost]
        [Route("creer-genre")]
        public async Task<IActionResult> CreerNouveauGenre([FromBody] CreateGenreDTO dto)
        {
            var reponse = await _genresService.CreerNouveauGenreAsync(dto);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpPut]
        [Route("{id:int}/modifier-genre")]
        public async Task<IActionResult> ModifierGenre(int id, [FromBody] CreateGenreDTO dto)
        {
            var reponse = await _genresService.ModifierGenreAsync(id, dto);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpDelete]
        [Route("{id:int}/supprimer-genre")]
        public async Task<IActionResult> SupprimerGenre(int id)
        {
            var reponse = await _genresService.SupprimerGenreAsync(id);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }
    }
}
