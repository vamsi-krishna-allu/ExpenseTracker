using Database.Models;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace ExpenseTracker.Controllers
{
    public class CalculateController : Controller
    {
        private readonly ILogger<CalculateController> _logger;
        private readonly IToastNotification toastNotification;

        public CalculateController(ILogger<CalculateController> logger, IToastNotification _toastNotification)
        {
            _logger = logger;
            toastNotification = _toastNotification;
        }

        public async Task<IActionResult> Expenses()
        {
            var expenses = await GetExpenses();
            ViewBag.ExpenseAmount = expenses;
            return View("../Calculate/Expenses");
        }

        public async Task<ExpenseTypeModelcs> GetExpenses()
        {
            var ExpenseTypeModelcs = new ExpenseTypeModelcs();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7249/");
                UserIdModel userIdModel = new UserIdModel();
                userIdModel.Id = Store.User.UserId;
                var result = await client.PostAsJsonAsync<UserIdModel>("Expense", userIdModel);

                if (result.IsSuccessStatusCode)
                {
                    var user = await result.Content.ReadAsStringAsync();
                    ExpenseTypeModelcs = JsonConvert.DeserializeObject<ExpenseTypeModelcs>(user);
                    
                    if (ExpenseTypeModelcs != null)
                    {
                        return ExpenseTypeModelcs;
                    }
                }
            }
            return ExpenseTypeModelcs;
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
                        toastNotification.AddSuccessToastMessage("Successfully logged in user "+userDbModel.FirstName);
                        return View("../Calculate/Index");
                    }
                    toastNotification.AddErrorToastMessage("Invalid Credentials! login failed");
                    return View("../Home/Index");
                }
            }
            toastNotification.AddErrorToastMessage("Server Error. Please contact administrator.");

            return View("../Home/Index");
        }

        [HttpPost]
        public async Task<IActionResult>? Back()
        {
            return View("../Calculate/Index");
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
                    toastNotification.AddSuccessToastMessage("Expense with amount " + expenseAmount + " saved succesfully for user");
                    return View("../Calculate/Index");
                }
                else
                {
                    toastNotification.AddErrorToastMessage("Saving expense amount failed for the user");
                    return View("../Calculate/Index");
                }
            }
        }
    }
}
