using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TestAspApi.Commons;
using TestAspApi.Contexts;
using TestAspApi.DTOs;
using TestAspApi.Models;
using TestAspApi.Services;
using TestAspApi.Services.Interface;

namespace TestAspApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LivreController : ControllerBase
    {
        private readonly ILivresService _livresService;

        public LivreController(ILivresService livresService)
        {
            _livresService = livresService;
        }

        [HttpGet]
        [Route("List-livre")]
        public async Task<IActionResult> GetLivres()
        {
            var reponse = await _livresService.GetAllAsync();

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpGet]
        [Route("{id:int}/get")]
        public async Task<IActionResult> GetOneLivre(int id)
        {
            var reponse = await _livresService.GetOneAsync(id);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpPost]
        [Route("Creer")]
        public async Task<IActionResult> AddLivre([FromBody] CreateLivreDTO dto)
        {
            if (ModelState.IsValid)
            {
                var reponse = await _livresService.CreerNouveauLivreAsync(dto);

                if (reponse.IsSucceed)
                {
                    return Ok(reponse);
                }

                return NotFound(reponse);
            }

             return NotFound(new Reponse<string>(false, "Le formulaire doit etre bien rempli"));

        }

        [HttpPut]
        [Route("{id:int}/editer")]
        public async Task<IActionResult> UpdateLivre(int id, [FromBody] CreateLivreDTO dto)
        {
            if (ModelState.IsValid)
            {
                var reponse = await _livresService.ModifierLivreAsync(id, dto);

                if (reponse.IsSucceed)
                {
                    return Ok(reponse);
                }

                return NotFound(reponse);

            }

            return NotFound(new Reponse<string>(false, "Le formulaire doit etre bien rempli"));
        }

        [HttpDelete]
        [Route("hard/{id:int}/delete")]
        public async Task<IActionResult> DeleteLivre(int id)
        {
            var reponse = await _livresService.SupprimerLivreAsync(id);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

    }
}
