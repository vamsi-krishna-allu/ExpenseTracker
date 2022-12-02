using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost]
        public IActionResult? Index(string firstName, string lastName, string email, string password, string repassword)
        {
            UserModel userModel = new UserModel(firstName, lastName, email, password);
            //TODO: need to pass this model to store data in database
            return View("../Home/Index");
        }
    }
}
