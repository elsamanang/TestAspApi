using TestAspApi.Commons;
using TestAspApi.DTOs;
using TestAspApi.Services.Interface;

namespace TestAspApi.Services
{
    public class StockService : IStockService
    {
        public Task<Reponse<StockDTO>> CreerNouveauStockAsync(CreateStockDTO createStockDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Reponse<IReadOnlyCollection<StockDTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Reponse<StockDTO>> GetOneAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Reponse<StockDTO>> ModifierStockAsync(int id, CreateStockDTO updateStockDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Reponse<StockDTO>> SupprimerStockAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
