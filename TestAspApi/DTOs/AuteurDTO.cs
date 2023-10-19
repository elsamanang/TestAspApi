using System.ComponentModel.DataAnnotations;

namespace TestAspApi.DTOs
{
    public class AuteurDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
