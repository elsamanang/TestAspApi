using TestAspApi.Commons;
using TestAspApi.DTOs;
using TestAspApi.Models;

namespace TestAspApi.Services.Interface
{
    public interface IAuteursService
    {
        /// <summary>
        /// Retourne la list de tous les auteurs disponible
        /// </summary>
        /// <returns><see cref="IReadOnlyCollection{T}"/> where <seealso cref="T"/> is <see cref="AuteurDTO"/></returns>
        Task<Reponse<IReadOnlyCollection<AuteurDTO>>> GetAllAsync();
        Task<Reponse<AuteurDTO>> GetByIdAsync(int id);
        Task<Reponse<Auteur>> GetByIdWithBooksAsync(int id);
        Task<Reponse<AuteurDTO>> CreerNouvelAuteurAsync(CreerAuteurDTO creerAuteur);
        Task<Reponse<AuteurDTO>> ModifierAuteurAsync(int id, EditerAuteurDTO editerAuteur);
        Task<Reponse<AuteurDTO>> SupprimerAuteurAsync(int id);
    }
}
