using System.ComponentModel.DataAnnotations;

namespace AzureProject.Models
{
    public class ForgetPasswordModel
    {
        [Required]
        [EmailAddress]
        public string EmailID { get; set; }

        public bool EmailIDSent { get; set; }
    }
}
