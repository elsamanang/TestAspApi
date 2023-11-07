using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAspApi.Commons;
using TestAspApi.DTOs;
using TestAspApi.Services.Interface;

namespace TestAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAll()
        {
            var reponse = await _operationService.GetAllAsync();

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpGet]
        [Route("list--by-date")]
        public async Task<IActionResult> GetAll(DateTime day)
        {
            var reponse = await _operationService.GetByDateAsync(day);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpGet]
        [Route("{id:int}/get-one")]
        public async Task<IActionResult> GetOne(int id)
        {
            var reponse = await _operationService.GetOneAsync(id);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpPost]
        [Route("creer")]
        public async Task<IActionResult> CreateNewOperation([FromBody] CreateOperationDTO createOperation)
        {
            if (ModelState.IsValid)
            {
                var reponse = await _operationService.CreerNouvelleOperationAsync(createOperation);

                if (reponse.IsSucceed)
                {
                    return Ok(reponse);
                }

                return NotFound(reponse);
            }

            return BadRequest(new Reponse<OperationDTO>(false, "Veuillez remplir tous les champs obligatoire"));
        }

        [HttpPut]
        [Route("{id:int}/modifier")]
        public async Task<IActionResult> UpdateOperation(int id, [FromBody] CreateOperationDTO updateOperation)
        {
            if (ModelState.IsValid)
            {
                var reponse = await _operationService.ModifierOperationAsync(id, updateOperation);

                if (reponse.IsSucceed)
                {
                    return Ok(reponse);
                }

                return NotFound(reponse);
            }

            return BadRequest(new Reponse<OperationDTO>(false, "Veuillez remplir tous les champs obligatoire"));
        }

        [HttpDelete]
        [Route("{id:int}/supprimer")]
        public async Task<IActionResult> DeleteOperation(int id)
        {
            var reponse = await _operationService.SupprimerOperationAsync(id);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }
    }
}
