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
            return View("../Home/Index");
        }
    }
}
