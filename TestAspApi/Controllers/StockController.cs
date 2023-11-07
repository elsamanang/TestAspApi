using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAspApi.Commons;
using TestAspApi.DTOs;
using TestAspApi.Services.Interface;

namespace TestAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        [Route("liste")]
        public async Task<IActionResult> GetAll()
        {
            var reponse = await _stockService.GetAllAsync();

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpGet]
        [Route("{id:int)/get-one")]
        public async Task<IActionResult> GetOne(int id)
        {
            var reponse = await _stockService.GetOneAsync(id);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpPost]
        [Route("creer")]
        public async Task<IActionResult> CreateNewStock([FromBody] CreateStockDTO newStock)
        {
            if (ModelState.IsValid)
            {
                var reponse = await _stockService.CreerNouveauStockAsync(newStock);

                if (reponse.IsSucceed)
                {
                    return Ok(reponse);
                }

                return NotFound(reponse);
            }

            return BadRequest(new Reponse<StockDTO>(false, "Veuillez remplir tous les champs obligatoire"));
        }

        [HttpPut]
        [Route("{id:int}/modifier")]
        public async Task<IActionResult> UpadteStock(int id, [FromBody] CreateStockDTO updateStock)
        {
            if (ModelState.IsValid)
            {
                var reponse = await _stockService.ModifierStockAsync(id, updateStock);

                if (reponse.IsSucceed)
                {
                    return Ok(reponse);
                }

                return NotFound(reponse);
            }

            return BadRequest(new Reponse<StockDTO>(false, "Veuillez remplir tous les champs obligatoire"));
        }

        [HttpDelete]
        [Route("{id:int}/supprimer")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var reponse = await _stockService.SupprimerStockAsync(id);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }
    }
}
