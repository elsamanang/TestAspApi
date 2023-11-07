using TestAspApi.Commons;
using TestAspApi.DTOs;
using TestAspApi.Models;

namespace TestAspApi.Services.Interface
{
    public interface ITypeOperationService
    {
        Task<Reponse<IReadOnlyCollection<TypeOperationDTO>>> GetAllAsync();
        Task<Reponse<TypeOperationDTO>> GetOneAsync(int id);
        Task<Reponse<TypeOperation>> GetWithOperationsAsync(int id);
        Task<Reponse<TypeOperationDTO>> CreeerTypeOperationAsync(CreateTypeOperationDTO createTypeOperationDTO);
        Task<Reponse<TypeOperationDTO>> ModifierTypeOperationAsync(int id, CreateTypeOperationDTO updateTypeOperationDTO);
        Task<Reponse<TypeOperationDTO>> SupprimerTypeOperationAsync(int id);
    }
}
