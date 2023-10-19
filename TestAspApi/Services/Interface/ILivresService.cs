using TestAspApi.Commons;
using TestAspApi.DTOs;

namespace TestAspApi.Services.Interface
{
    public interface ILivresService
    {
        Task<Reponse<IReadOnlyCollection<LivreDTO>>> GetAllAsync();
        Task<Reponse<LivreDTO>> GetOneAsync(int id);
        Task<Reponse<LivreDTO>> CreerNouveauLivreAsync(CreateLivreDTO createLivre);
        Task<Reponse<LivreDTO>> ModifierLivreAsync(int id, CreateLivreDTO modifierLivre);
        Task<Reponse<LivreDTO>> SupprimerLivreAsync(int id);

    }
}
