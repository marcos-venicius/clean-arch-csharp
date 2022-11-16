using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MinLength(3, ErrorMessage = "The name is too short. minimum 3 characters")]
        [MaxLength(100, ErrorMessage = "The name is greater than 100 characters")]
        public string Name { get; set; }
    }
}
