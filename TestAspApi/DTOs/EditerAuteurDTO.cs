using System.ComponentModel.DataAnnotations;

namespace TestAspApi.DTOs
{
#nullable disable
    public class EditerAuteurDTO
    {
        [Required(ErrorMessage = "Le nom de l'auteur doit toujours avoir une valeur")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le mail de l'auteur doit toujours avoir une valeur")]
        public string Email { get; set; }
    }
}
