using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureProject.Models
{
    public class Cart
    {
        [Required]
        [Key]
        public int CartId { get; set; }

        //ForeignKey
        [Display(Name = "User")]
        public virtual int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual UserMaster User { get; set; }

        //ForeignKey
        [Display(Name = "Product")]
        public virtual int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Products Product { get; set; }

        public string ProductName { get; set; }

        public float Price { get; set; }
    }
}
