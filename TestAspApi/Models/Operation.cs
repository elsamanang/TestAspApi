using System.ComponentModel.DataAnnotations;

namespace TestAspApi.Models
{
#nullable disable
    public class Operation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TypeOperationId { get; set; }
        [Required]
        public int Prix { get; set; }
        [Required]
        public int Quantite { get; set; }
        [Required]
        public DateTime Day { get; set; }

        public virtual TypeOperation TypeOperation { get; set; }
    }
}
