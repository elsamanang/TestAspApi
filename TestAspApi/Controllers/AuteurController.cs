using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TestAspApi.Commons;
using TestAspApi.Contexts;
using TestAspApi.DTOs;
using TestAspApi.Models;
using TestAspApi.Services.Interface;

namespace TestAspApi.Controllers
{
#nullable disable

    [Route("api/[controller]")]
    [ApiController]
    public class AuteurController : ControllerBase
    {
        private readonly IAuteursService _auteursService;

        public AuteurController(IAuteursService auteursService)
        {
            _auteursService = auteursService;
        }

        [HttpGet]
        [Route("list-auteur")]
        public async Task<IActionResult> GetAsync()
        {
            var reponse = await _auteursService.GetAllAsync();

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);

        }

        [HttpGet]
        [Route("{id:int}/get")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var reponse = await _auteursService.GetByIdAsync(id);
            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetByIdQueryAsync([FromQuery, Required] int id)
        {
            var reponse = await _auteursService.GetByIdAsync(id);
            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpPost]
        [Route("Creer")]
        public async Task<IActionResult> CreerAuteurAsync([FromBody] CreerAuteurDTO dTO)
        {
            if (ModelState.IsValid)
            {
                var reponse = await _auteursService.CreerNouvelAuteurAsync(dTO);
                if (reponse.IsSucceed)
                {
                    return Ok(reponse);
                }

                return NotFound(reponse);
            }

            return BadRequest(new Reponse<AuteurDTO>(false, "Veuillez remplir tous les champs obligatoire"));
        }

        [HttpPut]
        [Route("{id:int}/editer")]
        public async Task<IActionResult> EditerAuteruAsync(int id, [FromBody] EditerAuteurDTO auteur)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Reponse<string>(false, "Veuillez remplir les champs obligatoires"));

            var reponse = await _auteursService.ModifierAuteurAsync(id, auteur);
            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);

        }

        [HttpDelete]
        [Route("hard/{id:int}/delete")]
        public async Task<IActionResult> DeleteHardAsync(int id)
        {
            var reponse = await _auteursService.SupprimerAuteurAsync(id);
            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return BadRequest(reponse);
        }

        [HttpGet]
        [Route("{id:int}/with-book")]
        public async Task<IActionResult> GetAuteurAvecLivresAsync(int id)
        {
            var reponse = await _auteursService.GetByIdWithBooksAsync(id);
            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }
    }
}
