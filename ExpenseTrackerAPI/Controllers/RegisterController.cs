using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "registerUser")]
        public String RegisterUser(UserModel userModel)
        {
            new UserModel(userModel.UserId, userModel.FirstName, userModel.LastName, userModel.Email, userModel.Password);
            //TODO: need to pass this model to store data in database
            return "SUCCESS";
        }
    }
}
