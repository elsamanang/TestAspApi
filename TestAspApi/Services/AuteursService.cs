using Microsoft.EntityFrameworkCore;
using TestAspApi.Commons;
using TestAspApi.Contexts;
using TestAspApi.DTOs;
using TestAspApi.Models;
using TestAspApi.Services.Interface;

namespace TestAspApi.Services
{
    public class AuteursService : IAuteursService
    {
        private readonly ApplicationDbContext _context;

        public AuteursService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Reponse<AuteurDTO>> CreerNouvelAuteurAsync(CreerAuteurDTO creerAuteur)
        {
            try
            {
                var auteur = await _context.Auteurs.AddAsync(new Auteur
                {
                    Name = creerAuteur.Name,
                    Email = creerAuteur.Email
                });

                await _context.SaveChangesAsync();
                var auteurAjouter = new AuteurDTO
                {
                    Id = auteur.Entity.Id,
                    Email = auteur.Entity.Email,
                    Name = auteur.Entity.Name
                };

                return new Reponse<AuteurDTO>(true, "Nouvel auteur creer", auteurAjouter);
            }
            catch (Exception e)
            {
                return new Reponse<AuteurDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<IReadOnlyCollection<AuteurDTO>>> GetAllAsync()
        {
            try
            {
                var list = await _context.Auteurs.ToListAsync();

                var data = new List<AuteurDTO>();

                list.ForEach(a =>
                {
                    AuteurDTO dTO = new()
                    {
                        Id = a.Id,
                        Name = a?.Name,
                        Email = a?.Email
                    };

                    data.Add(dTO);
                });

                return new Reponse<IReadOnlyCollection<AuteurDTO>>(true, "Data found", data);
            }
            catch (Exception e)
            {
                return new Reponse<IReadOnlyCollection<AuteurDTO>>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<AuteurDTO>> GetByIdAsync(int id)
        {
            try 
            { 
                var auteurBrut = await _context.Auteurs.FirstOrDefaultAsync(x => x.Id == id);
                if (auteurBrut is not null)
                {
                    var auteur = new AuteurDTO
                    {
                        Id = auteurBrut.Id,
                        Name = auteurBrut?.Name,
                        Email = auteurBrut?.Email
                    };

                    Reponse<AuteurDTO> reponse = new(true, "Auteur cherché, trouvé.", auteur);
                    return reponse;
                }

                return new Reponse<AuteurDTO>(false, "Non trouvé");
            }
            catch (Exception e)
            {
                return new Reponse<AuteurDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<Auteur>> GetByIdWithBooksAsync(int id)
        {
            try 
            { 
                var auteurBrut = await _context
                                            .Auteurs
                                            .Include(a => a.Livres)
                                            .FirstOrDefaultAsync(x => x.Id == id);
                if (auteurBrut == null)
                    return new Reponse<Auteur>(false, "Aucun auteur n'a ete trouver avec ces identifiants");


                return new Reponse<Auteur>(true, "L'auteur et ses livres", auteurBrut);
            }
            catch (Exception e)
            {
                return new Reponse<Auteur>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<AuteurDTO>> ModifierAuteurAsync(int id, EditerAuteurDTO editerAuteur)
        {
            try
            {
                var auteurBrut = await _context.Auteurs.FirstOrDefaultAsync(x => x.Id == id);
                if (auteurBrut == null)
                    return new Reponse<AuteurDTO>(false, "Aucun auteur n'a ete trouver avec ces identifiants");

                auteurBrut.Name = editerAuteur.Name;
                auteurBrut.Email = editerAuteur.Email;

                var auteurMisAjour = _context.Auteurs.Update(auteurBrut);

                await _context.SaveChangesAsync();

                var data = new AuteurDTO
                {
                    Id = auteurMisAjour.Entity.Id,
                    Name = auteurMisAjour.Entity.Name,
                    Email = auteurMisAjour.Entity.Email
                };

                return new Reponse<AuteurDTO>(true, "Informations mis a jour avec succes", data);
            }
            catch (Exception e)
            {
                return new Reponse<AuteurDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<AuteurDTO>> SupprimerAuteurAsync(int id)
        {
            try
            {
                var auteurBrut = await _context.Auteurs.FirstOrDefaultAsync(x => x.Id == id);
                if (auteurBrut == null)
                    return new Reponse<AuteurDTO>(false, "Aucun auteur n'a ete trouver avec ces identifiants");

                var auteurSupprimer = _context.Auteurs.Remove(auteurBrut);
                await _context.SaveChangesAsync();

                var suppression = new AuteurDTO
                {
                    Id = auteurSupprimer.Entity.Id,
                    Name = auteurSupprimer.Entity.Name,
                    Email = auteurSupprimer.Entity.Email
                };
                return new Reponse<AuteurDTO>(true, $"L'auteur {auteurBrut.Name} a ete supprimer", suppression);
            }
            catch (Exception e)
            {
                return new Reponse<AuteurDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }
    }
}
