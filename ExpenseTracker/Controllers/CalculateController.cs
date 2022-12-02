using CoreLibrary;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class CalculateController : Controller
    {
        private readonly ILogger<CalculateController> _logger;

        public CalculateController(ILogger<CalculateController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult? Index(string username, string password)
        {
            if (username != null && password != null && Validators.IsPasswordValid(password))
            {
                return View();
            }
            return View("../Home/Index");
        }
    }
}
