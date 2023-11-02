using TestAspApi.Commons;
using TestAspApi.DTOs;

namespace TestAspApi.Services.Interface
{
    public interface IOperationService
    {
        Task<Reponse<IReadOnlyCollection<OperationDTO>>> GetAllAsync();
        Task<Reponse<IReadOnlyCollection<OperationDTO>>> GetByDateAsync(DateTime day);
        Task<Reponse<OperationDTO>> GetOneAsync(int id);
        Task<Reponse<OperationDTO>> CreerNouvelleOperationAsync(CreateOperationDTO createOperationDTO);
        Task<Reponse<OperationDTO>> ModifierOperationAsync(int id, CreateOperationDTO updateOperation);
        Task<Reponse<OperationDTO>> SupprimerOperationAsync(int id);
    }
}
