using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProj.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
      //  [MaxLength(50, ErrorMessage = "Name must contain more than 2 characters and less than 50"), MinLength(2)]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
