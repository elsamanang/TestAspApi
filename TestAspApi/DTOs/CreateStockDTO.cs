using System.ComponentModel.DataAnnotations;

namespace TestAspApi.DTOs
{
    public class CreateStockDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "La quantité doit être doit mentionnée")]
        public int Quantite { get; set; }
        [Required]
        public int LivreId { get; set; }
    }
}
