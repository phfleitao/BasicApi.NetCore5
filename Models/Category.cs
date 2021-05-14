using System.ComponentModel.DataAnnotations;

namespace BasicApi.NetCore5.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Field!")]
        [MaxLength(50, ErrorMessage = "Title cannot be greater then 50 characters")]
        public string Title { get; set; }
    }
}
