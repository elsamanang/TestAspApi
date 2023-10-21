using System.ComponentModel.DataAnnotations;

namespace TestAspApi.DTOs
{
#nullable disable
    public class CreateGenreDTO
    {
        [MinLength(length: 3, ErrorMessage = "Le nom doit avoir 3 charateres ou plus")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Veuillez saisir le genre")]
        public string Name { get; set; }
    }
}
