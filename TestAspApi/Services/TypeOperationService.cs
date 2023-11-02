using TestAspApi.Commons;
using TestAspApi.DTOs;
using TestAspApi.Services.Interface;

namespace TestAspApi.Services
{
    public class TypeOperationService : ITypeOperationService
    {
        public Task<Reponse<TypeOperationDTO>> CreeerTypeOperationAsync(CreateTypeOperationDTO createTypeOperationDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Reponse<IReadOnlyCollection<TypeOperationDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Reponse<TypeOperationDTO>> GetOneAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reponse<TypeOperationDTO>> GetWithOperationsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reponse<TypeOperationDTO>> ModifierTypeOperationAsync(int id, CreateTypeOperationDTO updateTypeOperationDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Reponse<TypeOperationDTO>> SupprimerTypeOperationAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
