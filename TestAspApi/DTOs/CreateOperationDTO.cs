using System.ComponentModel.DataAnnotations;

namespace TestAspApi.DTOs
{
#nullable disable
    public class CreateOperationDTO
    {
        [Required(AllowEmptyStrings =false, ErrorMessage = "Le prix doit être mentionné")]
        public int Prix { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "La quantité doit être mentionnée")]
        public int Quantite { get; set; }
        [Required]
        public DateTime Day { get; set; }
        [Required]
        public int TypeOperationId { get; set; }
        [Required]
        public int LivreId { get; set; }
    }
}
