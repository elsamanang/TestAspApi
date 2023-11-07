using Microsoft.EntityFrameworkCore;
using TestAspApi.Commons;
using TestAspApi.Contexts;
using TestAspApi.DTOs;
using TestAspApi.Models;
using TestAspApi.Services.Interface;

namespace TestAspApi.Services
{
    public class TypeOperationService : ITypeOperationService
    {
        private readonly ApplicationDbContext _context;
        public TypeOperationService(ApplicationDbContext context) { 
            _context = context;
        }

        public async Task<Reponse<TypeOperationDTO>> CreeerTypeOperationAsync(CreateTypeOperationDTO createTypeOperationDTO)
        {
            try
            {
                var typeOperationBrut = await _context.TypeOperations.AddAsync(new TypeOperation
                {
                    Name = createTypeOperationDTO.Name,
                });
                await _context.SaveChangesAsync();

                var data = new TypeOperationDTO
                {
                    Id = typeOperationBrut.Entity.Id,
                    Name = typeOperationBrut.Entity.Name,
                };

                return new Reponse<TypeOperationDTO>(true, "Type opération créé", data);
            }
            catch (Exception e)
            {
                return new Reponse<TypeOperationDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<IReadOnlyCollection<TypeOperationDTO>>> GetAllAsync()
        {
            try
            {
                var typeOperationBrut = await _context.TypeOperations.ToListAsync();
                var data = new List<TypeOperationDTO>();

                typeOperationBrut.ForEach(a =>
                {
                    var item = new TypeOperationDTO
                    {
                        Id = a.Id,
                        Name = a.Name,
                    };
                    data.Add(item);
                });

                return new Reponse<IReadOnlyCollection<TypeOperationDTO>>(true, "Liste trouvée", data);
            }
            catch (Exception e)
            {
                return new Reponse<IReadOnlyCollection<TypeOperationDTO>>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<TypeOperationDTO>> GetOneAsync(int id)
        {
            try
            {
                var typeOperationBrut = await _context.TypeOperations.FirstOrDefaultAsync(a => a.Id == id);
                if (typeOperationBrut == null)
                    return new Reponse<TypeOperationDTO>(false, "Le type d'opération choisi n'eiste pas !");

                var data = new TypeOperationDTO
                {
                    Id = typeOperationBrut.Id,
                    Name = typeOperationBrut.Name,
                };

                return new Reponse<TypeOperationDTO>(true, "Element trouvé", data);
            }
            catch (Exception e)
            {
                return new Reponse<TypeOperationDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<TypeOperation>> GetWithOperationsAsync(int id)
        {
            try
            {
                var typeOperationBrut = await _context.TypeOperations
                    .Include(a => a.Operations)
                    .FirstOrDefaultAsync(a =>  a.Id == id);
                if (typeOperationBrut == null)
                    return new Reponse<TypeOperation>(false, "Le type d'opération choisi n'eiste pas !");

                return new Reponse<TypeOperation>(true, "Element trouvée", typeOperationBrut);
            }
            catch (Exception e)
            {
                return new Reponse<TypeOperation>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<TypeOperationDTO>> ModifierTypeOperationAsync(int id, CreateTypeOperationDTO updateTypeOperationDTO)
        {
            try
            {
                var typeOperationBrut = await _context.TypeOperations.FirstOrDefaultAsync(a => a.Id == id);
                if (typeOperationBrut == null)
                    return new Reponse<TypeOperationDTO>(false, "Le type d'opération choisi n'eiste pas !");

                typeOperationBrut.Name = updateTypeOperationDTO.Name;
                var typeOperationUpdate = _context.TypeOperations.Update(typeOperationBrut);
                await _context.SaveChangesAsync();

                var data = new TypeOperationDTO
                {
                    Id = typeOperationUpdate.Entity.Id,
                    Name = typeOperationUpdate.Entity.Name
                };

                return new Reponse<TypeOperationDTO>(true, "Le type d'opération est à jour", data);
            }
            catch (Exception e)
            {
                return new Reponse<TypeOperationDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<TypeOperationDTO>> SupprimerTypeOperationAsync(int id)
        {
            try
            {
                var typeOperationBrut = await _context.TypeOperations.FirstOrDefaultAsync(a => a.Id == id);
                if (typeOperationBrut == null)
                    return new Reponse<TypeOperationDTO>(false, "Le type d'opération choisi n'eiste pas !");

                var typeOperationDelete = _context.TypeOperations.Remove(typeOperationBrut);
                await _context.SaveChangesAsync();

                var data = new TypeOperationDTO
                {
                    Id = typeOperationDelete.Entity.Id,
                    Name = typeOperationDelete.Entity.Name,
                };

                return new Reponse<TypeOperationDTO>(true, $"Le type d'opération {data.Name} a été supprimé", data);

            }
            catch (Exception e)
            {
                return new Reponse<TypeOperationDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }
    }
}
