using Database.Models;
using Database.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateController : ControllerBase
    {
        private readonly ILogger<CalculateController> _logger;
        private readonly IRepository<ExpenseDbModel> _repository;

        public CalculateController(ILogger<CalculateController> logger, IRepository<ExpenseDbModel> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost(Name = "calculateExpense")]
        public String CalculateExpense(ExpenseDbModel expenseDbModel)
        {
            if (expenseDbModel.ExpenseType != null && expenseDbModel.Amount != null)
            {
                _repository.Add(expenseDbModel);
                return "SUCCESS";
            }
            return "FAILURE";
        }
    }
}
