using Microsoft.EntityFrameworkCore;
using TestAspApi.Commons;
using TestAspApi.Contexts;
using TestAspApi.DTOs;
using TestAspApi.Models;
using TestAspApi.Services.Interface;

namespace TestAspApi.Services
{
    public class OperationService : IOperationService
    {
        private readonly ApplicationDbContext _context;

        public OperationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Reponse<OperationDTO>> CreerNouvelleOperationAsync(CreateOperationDTO createOperationDTO)
        {
            try
            {
                var operationBrut = await _context.Operations.AddAsync(new Operation
                {
                    TypeOperationId = createOperationDTO.TypeOperationId,
                    LivreId = createOperationDTO.LivreId,
                    Prix = createOperationDTO.Prix,
                    Quantite = createOperationDTO.Quantite,
                    Day = createOperationDTO.Day,
                });
                await _context.SaveChangesAsync();

                var data = new OperationDTO
                {
                    Id = operationBrut.Entity.Id,
                    Prix = operationBrut.Entity.Prix,
                    Quantite = operationBrut.Entity.Quantite,
                    Day = operationBrut.Entity.Day,
                    TypeOperationId = operationBrut.Entity.TypeOperationId,
                    LivreId = operationBrut.Entity.LivreId,
                };

                return new Reponse<OperationDTO>(true, "Opération créée", data);
            }
            catch (Exception e)
            {
                return new Reponse<OperationDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<IReadOnlyCollection<OperationDTO>>> GetAllAsync()
        {
            try
            {
                var operationBrut = await _context.Operations
                    .Include(a => a.TypeOperation)
                    .Include(a => a.Livre)
                    .ToListAsync();
                var data = new List<OperationDTO>();

                operationBrut.ForEach(a =>
                {
                    var item = new OperationDTO
                    {
                        Id = a.Id,
                        Prix = a.Prix,
                        Quantite = a.Quantite,
                        Day = a.Day,
                        TypeOperationId = a.TypeOperationId,
                        TypeOperationName = a.TypeOperation.Name,
                        LivreId = a.LivreId,
                        LivreTitle = a.Livre.Title,
                    };
                    data.Add(item);
                });

                return new Reponse<IReadOnlyCollection<OperationDTO>>(true, "Liste trouvée", data);
            }
            catch (Exception e)
            {
                return new Reponse<IReadOnlyCollection<OperationDTO>>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<IReadOnlyCollection<OperationDTO>>> GetByDateAsync(DateTime day)
        {
            try
            {
                var operationBrut = await _context.Operations
                    .Where(a => a.Day == day)
                    .Include(a => a.TypeOperation)
                    .Include (a => a.Livre)
                    .ToListAsync();
                var data = new List<OperationDTO>();

                operationBrut.ForEach(a =>
                {
                    var item = new OperationDTO
                    {
                        Id = a.Id,
                        Prix = a.Prix,
                        Quantite = a.Quantite,
                        Day = a.Day,
                        TypeOperationId = a.TypeOperationId,
                        TypeOperationName = a.TypeOperation.Name,
                        LivreId = a.LivreId,
                        LivreTitle = a.Livre.Title,
                    };
                    data.Add(item);
                });

                return new Reponse<IReadOnlyCollection<OperationDTO>>(true, "Liste trouvée", data);
            }
            catch (Exception e)
            {
                return new Reponse<IReadOnlyCollection<OperationDTO>>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<OperationDTO>> GetOneAsync(int id)
        {
            try
            {
                var operationBrut = await _context.Operations
                    .Include(a => a.TypeOperation)
                    .Include(a => a.Livre)
                    .FirstOrDefaultAsync(a => a.Id == id);
                if (operationBrut == null)
                    return new Reponse<OperationDTO>(false, "L'opération choisi n'eiste pas !");

                var data = new OperationDTO
                {
                    Id = operationBrut.Id,
                    Prix = operationBrut.Prix,
                    Quantite = operationBrut.Quantite,
                    Day = operationBrut.Day,
                    TypeOperationId = operationBrut.TypeOperationId,
                    TypeOperationName = operationBrut.TypeOperation.Name,
                    LivreId = operationBrut.LivreId,
                    LivreTitle = operationBrut.Livre.Title,
                };

                return new Reponse<OperationDTO>(true, "Element trouvé", data);
            }
            catch (Exception e)
            {
                return new Reponse<OperationDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<OperationDTO>> ModifierOperationAsync(int id, CreateOperationDTO updateOperation)
        {
            try
            {
                var operationBrut = await _context.Operations.FirstOrDefaultAsync(a => a.Id == id);
                if (operationBrut == null)
                    return new Reponse<OperationDTO>(false, "L'opération choisi n'eiste pas !");

                operationBrut.Prix = updateOperation.Prix;
                operationBrut.Quantite = updateOperation.Quantite;
                operationBrut.TypeOperationId = updateOperation.TypeOperationId;
                operationBrut.LivreId = updateOperation.LivreId;

                var operationUpdate = _context.Operations.Update(operationBrut);
                await _context.SaveChangesAsync();

                var data = new OperationDTO
                {
                    Id = operationUpdate.Entity.Id,
                    Prix = operationUpdate.Entity.Prix,
                    Quantite = operationUpdate.Entity.Quantite,
                    TypeOperationId = operationUpdate.Entity.TypeOperationId,
                    LivreId = operationUpdate.Entity.LivreId,
                };

                return new Reponse<OperationDTO>(true, "Opération à jour", data);
            }
            catch (Exception e)
            {
                return new Reponse<OperationDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<OperationDTO>> SupprimerOperationAsync(int id)
        {
            try
            {
                var operationBrut = await _context.Operations.FirstOrDefaultAsync(a => a.Id == id);
                if (operationBrut == null)
                    return new Reponse<OperationDTO>(false, "L'opération choisi n'eiste pas !");

                var operationDelete = _context.Operations.Remove(operationBrut);
                await _context.SaveChangesAsync();

                var data = new OperationDTO
                {
                    Id = operationDelete.Entity.Id,
                    Prix = operationDelete.Entity.Prix,
                    Quantite = operationDelete.Entity.Quantite,
                    TypeOperationId = operationDelete.Entity.TypeOperationId,
                    LivreId = operationDelete.Entity.LivreId,
                };

                return new Reponse<OperationDTO>(true, $"Opération supprimée", data);
            }
            catch (Exception e)
            {
                return new Reponse<OperationDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }
    }
}
