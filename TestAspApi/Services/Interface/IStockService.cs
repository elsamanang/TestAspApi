using TestAspApi.Commons;
using TestAspApi.DTOs;

namespace TestAspApi.Services.Interface
{
    public interface IStockService
    {
        Task<Reponse<IReadOnlyCollection<StockDTO>>> GetAllAsync();
        Task<Reponse<StockDTO>> GetOneAsync(int id);
        Task<Reponse<StockDTO>> CreerNouveauStockAsync(CreateStockDTO createStockDTO);
        Task<Reponse<StockDTO>> ModifierStockAsync(int id, CreateStockDTO updateStockDTO);
        Task<Reponse<StockDTO>> SupprimerStockAsync(int id);
    }
}
