using Database.Models;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

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
        public async Task<IActionResult>? Index(string username, string password)
        {
            LoginModel loginModel = new(username, password);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7249/");

                var result = await client.PostAsJsonAsync<LoginModel>("Home", loginModel);

                if (result.IsSuccessStatusCode)
                {
                    var user = await result.Content.ReadAsStringAsync();
                    var userDbModel = JsonConvert.DeserializeObject<UserDbModel>(user);
                    Store.User = userDbModel;
                    if (userDbModel != null && userDbModel.Email != null)
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
        public async Task<IActionResult>? SaveExpense(string expenseType, string expenseAmount)
        {
            ExpenseDbModel expenseModel = new ExpenseDbModel()
            {
                _id = Store.User.UserId + DateTime.Now.ToString(),
                ExpenseType = expenseType,
                Amount = expenseAmount,
                Date = DateTime.Now.ToString(),
                UserId = Store.User.UserId
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7249/");

                var result = await client.PostAsJsonAsync<ExpenseDbModel>("Calculate", expenseModel);
                
                if (result.IsSuccessStatusCode)
                {
                    return View("../Calculate/Index");
                }
                else
                {
                    return View();
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View();

        }
    }
}
