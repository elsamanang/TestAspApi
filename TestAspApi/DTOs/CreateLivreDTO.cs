using System.ComponentModel.DataAnnotations;

namespace TestAspApi.DTOs
{
#nullable disable
    public class CreateLivreDTO
    {
        [Required(AllowEmptyStrings =false, ErrorMessage ="Le livre doit avoir un titre")]
        [MinLength(length: 3, ErrorMessage ="Le titre doit avoir au moins 3 caracteres")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required]
        public int AuteurId { get; set; }
    }
}
