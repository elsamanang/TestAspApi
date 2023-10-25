using System.ComponentModel.DataAnnotations;

namespace TestAspApi.Models
{
#nullable disable
    public class TypeOperation
    {
        public TypeOperation() { 
            Operations = new HashSet<Operation>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Operation> Operations { get; set;}
    }
}
