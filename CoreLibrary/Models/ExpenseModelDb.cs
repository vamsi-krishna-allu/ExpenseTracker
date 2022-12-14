using System.ComponentModel.DataAnnotations;

namespace CoreLibrary.Models
{
    public class ExpenseModelDb
    {
        [Key]
        public string _id { get; set; }

        [Required]
        public string ExpenseType { get; set; }

        [Required]
        public string Amount { get; set; }

        [Required]
        public String Date { get; set; }

        [Required]
        public UserModelDb User { get; set; }

    }
}
