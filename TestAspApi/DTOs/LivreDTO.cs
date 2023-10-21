using System.ComponentModel.DataAnnotations;

namespace TestAspApi.DTOs
{
#nullable disable
    public class LivreDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required]
        public int AuteurID { get; set; }
        [Required]
        public int GenreId { get; set; }
        public string AuteurName { get; set; }
        
        public string AuteurEmail { get; set; }
        public string GenreName { get; set; }
    }
}
