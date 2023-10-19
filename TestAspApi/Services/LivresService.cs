using Microsoft.EntityFrameworkCore;
using TestAspApi.Commons;
using TestAspApi.Contexts;
using TestAspApi.DTOs;
using TestAspApi.Models;
using TestAspApi.Services.Interface;

namespace TestAspApi.Services
{
#nullable disable
    public class LivresService : ILivresService
    {
        private readonly ApplicationDbContext _context;

        public LivresService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Reponse<LivreDTO>> CreerNouveauLivreAsync(CreateLivreDTO createLivre)
        {
            try
            {
                var ajout = await _context.Livres.AddAsync(new Livre
                {
                    Title = createLivre.Title,
                    Description = createLivre.Description,
                    Pages = createLivre.Pages,
                    AuteurId = createLivre.AuteurId
                });

                await _context.SaveChangesAsync();

                var data = new LivreDTO
                {
                    Id = ajout.Entity.Id,
                    Title = createLivre.Title,
                    Description = createLivre.Description,
                    Pages = createLivre.Pages,
                    AuteurID = createLivre.AuteurId
                };

                return new Reponse<LivreDTO>(true, "Element ajouté", data);
            }
            catch (Exception e) 
            {
                return new Reponse<LivreDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<IReadOnlyCollection<LivreDTO>>> GetAllAsync()
        {
            try
            {
                var list = await _context
                .Livres
                .Include(a => a.Auteur)
                .ToListAsync();

                var data = new List<LivreDTO>();

                list.ForEach(a =>
                    {
                        LivreDTO dto = new()
                        {
                            Id = a.Id,
                            Title = a.Title,
                            Pages = a.Pages,
                            Description = a.Description,
                            AuteurID = a.AuteurId,
                            AuteurName = a.Auteur.Name,
                            AuteurEmail = a.Auteur.Email
                        };

                     data.Add(dto);
                });

                return new Reponse<IReadOnlyCollection<LivreDTO>>(true, "Element trouvé", data);
            }
            catch (Exception e)
            {
                return new Reponse<IReadOnlyCollection<LivreDTO>>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<LivreDTO>> GetOneAsync(int id)
        {
            try
            {
                var oneLivre = await _context
                .Livres
                .Include(a => a.Auteur)
                .FirstOrDefaultAsync(a => a.Id == id);

                if (oneLivre is not null)
                {
                    var data = new LivreDTO
                    {
                        Id = oneLivre.Id,
                        Title = oneLivre.Title,
                        Pages = oneLivre.Pages,
                        Description = oneLivre.Description,
                        AuteurID = oneLivre.AuteurId,
                        AuteurName = oneLivre.Auteur.Name,
                        AuteurEmail = oneLivre.Auteur.Email
                    };

                    return new Reponse<LivreDTO>(true, "Element trouvé", data);
                }

                return new Reponse<LivreDTO>(false, "L'element n'existe pas");
            }
            catch (Exception e)
            {
                return new Reponse<LivreDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<LivreDTO>> ModifierLivreAsync(int id, CreateLivreDTO modifierLivre)
        {
            try
            {
                var findLivre = await _context.Livres.FirstOrDefaultAsync(a => a.Id == id);

                if (findLivre is not null)
                {
                    findLivre.Title = modifierLivre.Title;
                    findLivre.Description = modifierLivre.Description;
                    findLivre.Pages = modifierLivre.Pages;
                    findLivre.AuteurId = modifierLivre.AuteurId;

                    var updateLivre = _context.Livres.Update(findLivre);
                    await _context.SaveChangesAsync();

                    var data = new LivreDTO
                    {
                        Id = updateLivre.Entity.Id,
                        Title = updateLivre.Entity.Title,
                        Description = updateLivre.Entity.Description,
                        Pages = updateLivre.Entity.Pages,
                        AuteurID = updateLivre.Entity.AuteurId
                    };

                    return new Reponse<LivreDTO>(true, $"Le livre {data.Title} a ete mise a jour", data);
                }

                return new Reponse<LivreDTO>(false, "L'element que vous voulez modifier n'existe pas");
            }
            catch (Exception e)
            {
                return new Reponse<LivreDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<LivreDTO>> SupprimerLivreAsync(int id)
        {
            try
            {
                var findLivre = await _context.Livres.FirstOrDefaultAsync(a => a.Id == id);

                if (findLivre is not null)
                {
                    var deleteLivre = _context.Livres.Remove(findLivre);
                    await _context.SaveChangesAsync();

                    var data = new LivreDTO
                    {
                        Id = deleteLivre.Entity.Id,
                        Title = deleteLivre.Entity.Title,
                        Description = deleteLivre.Entity.Description,
                        Pages = deleteLivre.Entity.Pages,
                        AuteurID = deleteLivre.Entity.AuteurId
                    };

                    return new Reponse<LivreDTO>(true, $"Le livre {data.Title} a ete supprimé", data);
                }

                return new Reponse<LivreDTO>(false, "L'element que vous voulez supprimer n'existe pas");
            }
            catch (Exception e)
            {
                return new Reponse<LivreDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }
    }
}
