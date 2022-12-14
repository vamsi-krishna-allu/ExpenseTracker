using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoreLibrary.Models
{
    public class UserModelDb
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }

        public ICollection<ExpenseModelDb> ExpenseModels { get; set; } = new List<ExpenseModelDb>();

    }
}
