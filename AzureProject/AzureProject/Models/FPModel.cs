using System.ComponentModel.DataAnnotations;

namespace AzureProject.Models
{
    public class FPModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Q1 { get; set; }

        [Required]
        public string Q2 { get; set; }

    }
}
