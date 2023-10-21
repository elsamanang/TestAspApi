using System.ComponentModel.DataAnnotations;

namespace TestAspApi.Models
{
    public class Genre
    {
        public Genre() {
            Livres = new HashSet<Livre>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public virtual ICollection<Livre> Livres { get; set; }
    }
}
