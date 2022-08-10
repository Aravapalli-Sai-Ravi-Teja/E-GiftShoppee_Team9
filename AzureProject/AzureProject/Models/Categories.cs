using System.ComponentModel.DataAnnotations;

namespace AzureProject.Models
{
    public class Categories
    {
        [Required]
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Category { get; set; }
        
    }
}
