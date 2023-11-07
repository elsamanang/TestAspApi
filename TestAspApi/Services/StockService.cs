using Microsoft.EntityFrameworkCore;
using TestAspApi.Commons;
using TestAspApi.Contexts;
using TestAspApi.DTOs;
using TestAspApi.Models;
using TestAspApi.Services.Interface;

namespace TestAspApi.Services
{
    public class StockService : IStockService
    {
        private readonly ApplicationDbContext _context;

        public StockService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Reponse<StockDTO>> CreerNouveauStockAsync(CreateStockDTO createStockDTO)
        {
            try
            {
                var stockBrut = await _context.Stocks.AddAsync(new Stock
                {
                    Quantite = createStockDTO.Quantite,
                    LivreId = createStockDTO.LivreId,
                });
                await _context.SaveChangesAsync();

                var data = new StockDTO
                {
                    Id = stockBrut.Entity.Id,
                    Quantite = stockBrut.Entity.Quantite,
                    LivreId = stockBrut.Entity.LivreId,
                };

                return new Reponse<StockDTO>(true, "Le stock a été créé", data);
            }
            catch (Exception e)
            {
                return new Reponse<StockDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<IReadOnlyCollection<StockDTO>>> GetAllAsync()
        {
            try
            {
                var stockBrut = await _context.Stocks.Include(a => a.Livre).ToListAsync();
                var data = new List<StockDTO>();

                stockBrut.ForEach(a =>
                {
                    var item = new StockDTO
                    {
                        Id = a.Id,
                        Quantite = a.Quantite,
                        LivreId = a.LivreId,
                        LivreTitle = a.Livre.Title,
                    };
                    data.Add(item);
                });

                return new Reponse<IReadOnlyCollection<StockDTO>>(true, "Liste trouvée", data);
            }
            catch (Exception e)
            {
                return new Reponse<IReadOnlyCollection<StockDTO>>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<StockDTO>> GetOneAsync(int id)
        {
            try
            {
                var stockBrut = await _context.Stocks
                    .Include(a => a.Livre)
                    .FirstOrDefaultAsync(a => a.Id == id);
                if (stockBrut == null)
                    return new Reponse<StockDTO>(false, "Le stock choisi n'existe pas !");

                var data = new StockDTO
                {
                    Id = stockBrut.Id,
                    Quantite = stockBrut.Quantite,
                    LivreId = stockBrut.LivreId,
                    LivreTitle = stockBrut.Livre.Title
                };

                return new Reponse<StockDTO>(true, $"Element trouvé", data);
            }
            catch (Exception e)
            {
                return new Reponse<StockDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<StockDTO>> ModifierStockAsync(int id, CreateStockDTO updateStockDTO)
        {
            try
            {
                var stockBrut = await _context.Stocks.FirstOrDefaultAsync(a => a.Id == id);
                if (stockBrut == null)
                    return new Reponse<StockDTO>(false, "Le stock choisi n'existe pas !");

                stockBrut.Quantite = updateStockDTO.Quantite;
                stockBrut.LivreId = updateStockDTO.LivreId;
                var stockUpdate = _context.Stocks.Update(stockBrut);
                await _context.SaveChangesAsync();

                var data = new StockDTO
                {
                    Id = stockUpdate.Entity.Id,
                    Quantite = stockUpdate.Entity.Quantite,
                    LivreId = stockUpdate.Entity.LivreId
                };

                return new Reponse<StockDTO>(true, "Le stock est à jour", data);
            }
            catch (Exception e)
            {
                return new Reponse<StockDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<StockDTO>> SupprimerStockAsync(int id)
        {
            try
            {
                var stockBrut = await _context.Stocks.FirstOrDefaultAsync(a => a.Id == id);
                if (stockBrut == null)
                    return new Reponse<StockDTO>(false, "Le stock choisi n'existe pas !");

                var stockDelete = _context.Stocks.Remove(stockBrut);
                await _context.SaveChangesAsync();

                var data = new StockDTO
                {
                    Id = stockDelete.Entity.Id,
                    Quantite = stockDelete.Entity.Quantite,
                    LivreId = stockDelete.Entity.LivreId
                };

                return new Reponse<StockDTO>(true, "Le stock a été supprimé", data);
            }
            catch (Exception e)
            {
                return new Reponse<StockDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }
    }
}
