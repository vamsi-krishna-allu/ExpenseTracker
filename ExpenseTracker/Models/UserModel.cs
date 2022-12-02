using System.Text.Json.Serialization;

namespace ExpenseTracker.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public string UserId { get; set; }
       
        public UserModel(string FirstName, string LastName, string Email, string Password)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password  = Password;
        }

    }
}
