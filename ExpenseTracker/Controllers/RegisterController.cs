using Database.Models;
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
            UserModel userModel = new UserModel("1", firstName, lastName, email, password);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7249/");

                var postTask = client.PostAsJsonAsync<UserModel>("Register", userModel);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var status = result.Content.ReadFromJsonAsync<string>().Result;
                    if(status == "SUCCESS")
                    {
                        return View("../Home/Index");
                    }else
                    {
                        return View();
                    }
                    
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View();
            
        }

        
    }
}
