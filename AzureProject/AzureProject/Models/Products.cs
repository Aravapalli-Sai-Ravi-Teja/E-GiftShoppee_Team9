using System.ComponentModel.DataAnnotations;

namespace AzureProject.Models
{
    public class Products
    {
        [Required]
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public float Price { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
