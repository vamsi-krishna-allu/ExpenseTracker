using Database.Models;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace ExpenseTracker.Controllers
{
    public class CalculateController : Controller
    {
        private readonly ILogger<CalculateController> _logger;

        private UserDbModel userDbModel;

        public CalculateController(ILogger<CalculateController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult? Index(string username, string password)
        {
            LoginModel loginModel = new(username, password);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7249/");

                var postTask = client.PostAsJsonAsync<LoginModel>("Home", loginModel);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    userDbModel = result.Content.ReadFromJsonAsync<UserDbModel>().Result;
                    if(userDbModel != null && userDbModel.Email != null)
                    {
                        return View("../Calculate/Index");
                    }
                    return View();
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View();
        }

        [HttpPost]
        public IActionResult? SaveExpense(string expenseType, string expenseAmount)
        {
            ExpenseDbModel expenseModel = new ExpenseDbModel()
            {
                _id = "1",
                ExpenseType = expenseType,
                Amount = expenseAmount,
                Date = new DateTime().ToString(),
                User = userDbModel
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7249/");

                var postTask = client.PostAsJsonAsync<ExpenseDbModel>("Calculate", expenseModel);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var status = result.Content.ReadFromJsonAsync<string>().Result;
                    if (status == "SUCCESS")
                    {
                        return View("../Home/Index");
                    }
                    else
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
