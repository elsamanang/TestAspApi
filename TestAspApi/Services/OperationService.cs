using TestAspApi.Commons;
using TestAspApi.DTOs;
using TestAspApi.Services.Interface;

namespace TestAspApi.Services
{
    public class OperationService : IOperationService
    {
        public Task<Reponse<OperationDTO>> CreerNouvelleOperationAsync(CreateOperationDTO createOperationDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Reponse<IReadOnlyCollection<OperationDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Reponse<IReadOnlyCollection<OperationDTO>>> GetByDateAsync(DateTime day)
        {
            throw new NotImplementedException();
        }

        public Task<Reponse<OperationDTO>> GetOneAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reponse<OperationDTO>> ModifierOperationAsync(int id, CreateOperationDTO updateOperation)
        {
            throw new NotImplementedException();
        }

        public Task<Reponse<OperationDTO>> SupprimerOperationAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
