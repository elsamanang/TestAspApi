using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAspApi.Commons;
using TestAspApi.DTOs;
using TestAspApi.Services.Interface;

namespace TestAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOperationController : ControllerBase
    {
        private readonly ITypeOperationService _typeOperationService;

        public TypeOperationController(ITypeOperationService typeOperationService)
        {
            _typeOperationService = typeOperationService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAll() {
            var reponse = await _typeOperationService.GetAllAsync();

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
            var reponse = await _typeOperationService.GetOneAsync(id);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpGet]
        [Route("{id:int}/get-with-operation")]
        public async Task<IActionResult> GetWithOperation(int id)
        {
            var reponse = await _typeOperationService.GetWithOperationsAsync(id);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }

        [HttpPost]
        [Route("creer")]
        public async Task<IActionResult> CreateNewTypeOperation([FromBody] CreateTypeOperationDTO newTypeOperation)
        {
            if(ModelState.IsValid)
            {

                var reponse = await _typeOperationService.CreeerTypeOperationAsync(newTypeOperation);

                if (reponse.IsSucceed)
                {
                    return Ok(reponse);
                }

                return NotFound(reponse);
            }

            return BadRequest(new Reponse<TypeOperationDTO>(false, "Veuillez remplir tous les champs obligatoire"));
        }

        [HttpPut]
        [Route("{id:int}/modifier")]
        public async Task<IActionResult> UpdateTypeOperation(int id, [FromBody] CreateTypeOperationDTO updatetypeOperation)
        {
            if (ModelState.IsValid)
            {

                var reponse = await _typeOperationService.ModifierTypeOperationAsync(id, updatetypeOperation);

                if (reponse.IsSucceed)
                {
                    return Ok(reponse);
                }

                return NotFound(reponse);
            }

            return BadRequest(new Reponse<TypeOperationDTO>(false, "Veuillez remplir tous les champs obligatoire"));
        }

        [HttpDelete]
        [Route("{id:int}/supprimer")]
        public async Task<IActionResult> DeleteTypeOperation(int id)
        {
            var reponse = await _typeOperationService.SupprimerTypeOperationAsync(id);

            if (reponse.IsSucceed)
            {
                return Ok(reponse);
            }

            return NotFound(reponse);
        }
    }
}
