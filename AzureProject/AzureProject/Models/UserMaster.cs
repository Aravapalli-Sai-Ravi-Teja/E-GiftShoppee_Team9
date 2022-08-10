using System.ComponentModel.DataAnnotations;

namespace AzureProject.Models
{
    public class UserMaster
    {
        [Required]
        [Key]
        public int UserID { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string EmailID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public int Role { get; set; }

        [Required]
        public string Q1 { get; set; }

        [Required]
        public string Q2 { get; set; }

    }
}
