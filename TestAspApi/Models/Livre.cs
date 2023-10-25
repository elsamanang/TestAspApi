using System.ComponentModel.DataAnnotations;

namespace TestAspApi.Models
{
    public class Livre
    {
        public Livre() {
            Stocks = new HashSet<Stock>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required]
        public int AuteurId { get; set; }
        [Required]
        public int GenreId { get; set; }

        public virtual Auteur? Auteur { get; set;}
        public virtual Genre? Genre { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
