using System.ComponentModel.DataAnnotations;

namespace TestAspApi.DTOs
{
#nullable disable
    public class CreerAuteurDTO
    {
        [MinLength(length: 3, ErrorMessage = "Le nom doit avoir 3 charateres ou plus")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez saisir le nom de l'auteur")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage ="Saisissez une addresse mail valide")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "L'email est obligatoir. car nous devons etre en mesure de vous contacter")]
        public string Email { get; set; }
    }
}
