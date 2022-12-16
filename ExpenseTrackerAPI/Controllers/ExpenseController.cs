using Database.Models;
using Database.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly ILogger<ExpenseController> _logger;
        private readonly IRepository<ExpenseDbModel> _repository;

        public ExpenseController(ILogger<ExpenseController> logger, IRepository<ExpenseDbModel> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost(Name = "getExpense")]
        public ExpenseTypeModelcs GetExpenses(UserIdModel userIdModel)
        {
            ExpenseTypeModelcs ExpenseTypeModelcs = new();
            List<ExpenseDbModel> expenseModels = new();
            if (userIdModel != null)
            {
                expenseModels = _repository.GetAll();
                expenseModels = expenseModels.FindAll(x => x.UserId == userIdModel.Id);
                
                foreach (ExpenseDbModel expense in expenseModels)
                {
               
                    if(expense.ExpenseType == "Groceries")
                    {
                        ExpenseTypeModelcs.Groceries = ExpenseTypeModelcs.Groceries != null ? (Int16.Parse(ExpenseTypeModelcs.Groceries) + Int16.Parse(expense.Amount)).ToString() : expense.Amount;
                    }
                    else if (expense.ExpenseType == "Bus Pass")
                    {
                        ExpenseTypeModelcs.BusPass = ExpenseTypeModelcs.BusPass != null ? (Int16.Parse(ExpenseTypeModelcs.BusPass) + Int16.Parse(expense.Amount)).ToString() : expense.Amount;
                    }
                    else if (expense.ExpenseType == "Phone Bill")
                    {
                        ExpenseTypeModelcs.PhoneBill = ExpenseTypeModelcs.PhoneBill != null ? (Int16.Parse(ExpenseTypeModelcs.PhoneBill) + Int16.Parse(expense.Amount)).ToString() : expense.Amount;
                    }
                    else if (expense.ExpenseType == "Subscriptions")
                    {
                        ExpenseTypeModelcs.Subscriptions = ExpenseTypeModelcs.Subscriptions != null ? (Int16.Parse(ExpenseTypeModelcs.Subscriptions) + Int16.Parse(expense.Amount)).ToString() : expense.Amount;
                    }
                    else if (expense.ExpenseType == "Alcohol")
                    {
                        ExpenseTypeModelcs.Alcohol = ExpenseTypeModelcs.Alcohol != null ? (Int16.Parse(ExpenseTypeModelcs.Alcohol) + Int16.Parse(expense.Amount)).ToString() : expense.Amount;
                    }
                    else if (expense.ExpenseType == "Furniture")
                    {
                        ExpenseTypeModelcs.Furniture = ExpenseTypeModelcs.Furniture != null ? (Int16.Parse(ExpenseTypeModelcs.Furniture) + Int16.Parse(expense.Amount)).ToString() : expense.Amount;
                    }
                    else if (expense.ExpenseType == "Taxi or Travel")
                    {
                        ExpenseTypeModelcs.TaxiorTravel = ExpenseTypeModelcs.TaxiorTravel != null ? (Int16.Parse(ExpenseTypeModelcs.TaxiorTravel) + Int16.Parse(expense.Amount)).ToString() : expense.Amount;
                    }
                    else if (expense.ExpenseType == "Electricity")
                    {
                        ExpenseTypeModelcs.Electricity = ExpenseTypeModelcs.Electricity != null ? (Int16.Parse(ExpenseTypeModelcs.Electricity) + Int16.Parse(expense.Amount)).ToString() : expense.Amount;
                    }
                    else if (expense.ExpenseType == "Hydro")
                    {
                        ExpenseTypeModelcs.Hydro = ExpenseTypeModelcs.Hydro != null ? (Int16.Parse(ExpenseTypeModelcs.Hydro) + Int16.Parse(expense.Amount)).ToString() : expense.Amount;
                    }
                    else if (expense.ExpenseType == "Laundry")
                    {
                        ExpenseTypeModelcs.Laundry = ExpenseTypeModelcs.Laundry != null ? (Int16.Parse(ExpenseTypeModelcs.Laundry) + Int16.Parse(expense.Amount)).ToString() : expense.Amount;
                    }
                    else if (expense.ExpenseType == "Miscellaneous")
                    {
                        ExpenseTypeModelcs.Miscellaneous = ExpenseTypeModelcs.Miscellaneous != null ? (Int16.Parse(ExpenseTypeModelcs.Miscellaneous) + Int16.Parse(expense.Amount)).ToString() : expense.Amount;
                    }
                }
            }
            return ExpenseTypeModelcs;
        }
    }
}
