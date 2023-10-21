using TestAspApi.Commons;
using TestAspApi.DTOs;
using TestAspApi.Models;

namespace TestAspApi.Services.Interface
{
    public interface IGenresService
    {
        Task<Reponse<IReadOnlyCollection<GenreDTO>>> GetAllAsync();
        Task<Reponse<Genre>> GetGenreWithLivresAsync(int id);
        Task<Reponse<GenreDTO>> GetOneGenreAsync(int id);
        Task<Reponse<GenreDTO>> CreerNouveauGenreAsync(CreateGenreDTO creerGenre);
        Task<Reponse<GenreDTO>> ModifierGenreAsync(int id, CreateGenreDTO modifierGenre);
        Task<Reponse<GenreDTO>> SupprimerGenreAsync(int id);
    }
}
