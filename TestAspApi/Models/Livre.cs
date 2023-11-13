using System.ComponentModel.DataAnnotations;

namespace TestAspApi.Models
{
    public class Livre
    {
        public Livre() {
            Operations = new HashSet<Operation>();
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
        public virtual Stock? Stock { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
