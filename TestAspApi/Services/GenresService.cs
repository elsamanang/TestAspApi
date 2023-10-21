using Microsoft.EntityFrameworkCore;
using TestAspApi.Commons;
using TestAspApi.Contexts;
using TestAspApi.DTOs;
using TestAspApi.Models;
using TestAspApi.Services.Interface;

namespace TestAspApi.Services
{
    public class GenresService : IGenresService
    {
        private readonly ApplicationDbContext _context;

        public GenresService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Reponse<GenreDTO>> CreerNouveauGenreAsync(CreateGenreDTO creerGenre)
        {
            try
            {
                var genre = await _context.Genres.AddAsync(new Genre
                {
                    Name = creerGenre.Name
                });
                await _context.SaveChangesAsync();

                var genreAjouter = new GenreDTO
                {
                    Id = genre.Entity.Id,
                    Name = genre.Entity.Name
                };
                return new Reponse<GenreDTO>(true, "Nouveau genre ajouté", genreAjouter);
            }
            catch(Exception e) 
            { 
                return new Reponse<GenreDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<IReadOnlyCollection<GenreDTO>>> GetAllAsync()
        {
            try
            {
                var genres = await _context.Genres.ToListAsync();
                var data = new List<GenreDTO>();

                genres.ForEach(a =>
                {
                    GenreDTO dto = new()
                    {
                        Id = a.Id,
                        Name = a.Name
                    };
                    data.Add(dto);
                });

                return new Reponse<IReadOnlyCollection<GenreDTO>>(true, "Liste genres", data);
            }
            catch (Exception e)
            {
                return new Reponse<IReadOnlyCollection<GenreDTO>>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<Genre>> GetGenreWithLivresAsync(int id)
        {
            try
            {
                var genresBrut = await _context
                    .Genres
                    .Include(a => a.Livres)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if(genresBrut == null)
                    return new Reponse<Genre>(false, "Aucun genre n'a été trouvé avec ces identifiants");
                return new Reponse<Genre>(true, "Element trouvé", genresBrut);
            }
            catch (Exception e)
            {
                return new Reponse<Genre>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<GenreDTO>> GetOneGenreAsync(int id)
        {
            try
            {
                var genresBrut = await _context.Genres.FirstOrDefaultAsync(a => a.Id == id);

                if (genresBrut == null)
                    return new Reponse<GenreDTO>(false, "Aucun genre n'a été trouvé avec ces identifiants");

                var data = new GenreDTO
                {
                    Id = genresBrut.Id,
                    Name = genresBrut.Name
                };

                return new Reponse<GenreDTO>(true, "Element trouvé", data);
            }
            catch (Exception e)
            {
                return new Reponse<GenreDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<GenreDTO>> ModifierGenreAsync(int id, CreateGenreDTO modifierGenre)
        {
            try
            {
                var genreBrut = await _context.Genres.FirstOrDefaultAsync(a=> a.Id == id);
                if (genreBrut == null)
                    return new Reponse<GenreDTO>(false, "Aucun genre n'a été trouvé avec ces identifiants");
                
                genreBrut.Name = modifierGenre.Name;
                var genreModifier = _context.Genres.Update(genreBrut);
                await _context.SaveChangesAsync();

                var data = new GenreDTO
                {
                    Id = genreModifier.Entity.Id,
                    Name = genreModifier.Entity.Name
                };

                return new Reponse<GenreDTO>(true, "Les informations ont été mises à jour", data);
            }
            catch (Exception e)
            {
                return new Reponse<GenreDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }

        public async Task<Reponse<GenreDTO>> SupprimerGenreAsync(int id)
        {
            try
            {
                var genreBrut = await _context.Genres.FirstOrDefaultAsync(a => a.Id == id);
                if (genreBrut == null)
                    return new Reponse<GenreDTO>(false, "Aucun genre n'a été trouvé avec ces identifiants");

                var genreSupprimer = _context.Genres.Remove(genreBrut);
                await _context.SaveChangesAsync();

                var data = new GenreDTO
                {
                    Id = genreSupprimer.Entity.Id,
                    Name = genreSupprimer.Entity.Name
                };

                return new Reponse<GenreDTO>(true, $"Le genre {data.Name} a été supprimé", data);
            }
            catch (Exception e)
            {
                return new Reponse<GenreDTO>(false, $"{e.Message}\n\r{e?.InnerException?.Message}");
            }
        }
    }
}
