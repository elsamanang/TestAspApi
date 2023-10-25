using System.ComponentModel.DataAnnotations;

namespace TestAspApi.Models
{
#nullable disable
    public class Stock
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string LivreId { get; set; }
        [Required]
        public int Quantite { get; set; }

        public virtual Livre Livre { get; set; }
    }
}
