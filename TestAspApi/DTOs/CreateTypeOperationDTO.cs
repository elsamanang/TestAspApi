using System.ComponentModel.DataAnnotations;

namespace TestAspApi.DTOs
{
#nullable disable
    public class CreateTypeOperationDTO
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le nom doit être doit mentionné")]
        public string Name { get; set; }
    }
}
