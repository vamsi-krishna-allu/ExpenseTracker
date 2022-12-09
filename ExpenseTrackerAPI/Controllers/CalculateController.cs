using CoreLibrary;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateController : ControllerBase
    {
        private readonly ILogger<CalculateController> _logger;

        public CalculateController(ILogger<CalculateController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "calculateExpense")]
        public String CalculateExpense(string expenseType, string expenseAmount)
        {
            if (expenseType != null && expenseAmount != null)
            {
                return "SUCCESS";
            }
            return "FAILURE";
        }
    }
}
