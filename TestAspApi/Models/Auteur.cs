using System.ComponentModel.DataAnnotations;

namespace TestAspApi.Models
{
    public class Auteur
    {
        public Auteur()
        {
            Livres = new HashSet<Livre>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Email { get; set; }

        //prop de navigation
        public virtual ICollection<Livre> Livres { get; set; }
    }
}
