using CoreLibrary;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "validateUser")]
        public String ValidateUser(LoginModel loginModel)
        {
            if (loginModel.Email != null && loginModel.Password != null && Validators.IsPasswordValid(loginModel.Password) && EmailValidator.IsEmailValid(loginModel.Email))
            {
                return "SUCCESS";
            }
            return "FAILURE";
        }

    }
}