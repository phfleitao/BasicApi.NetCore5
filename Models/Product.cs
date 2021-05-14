using System.ComponentModel.DataAnnotations;

namespace BasicApi.NetCore5.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required Field!")]
        [MaxLength(50, ErrorMessage = "Title cannot be greater then 50 characters")]
        public string Title { get; set; }

        [MaxLength(2000, ErrorMessage = "Title cannot be greater then 2000 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required Field!")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Required Field!")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Category!")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
