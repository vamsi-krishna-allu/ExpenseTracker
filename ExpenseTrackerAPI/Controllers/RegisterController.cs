using Database.Models;
using Database.Repository;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly IRepository<UserDbModel> _repository;

        public RegisterController(ILogger<RegisterController> logger, IRepository<UserDbModel> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost(Name = "registerUser")]
        public String RegisterUser(UserModel userModel)
        {
            var userDbModel = new UserDbModel()
            {
                UserId = userModel.Email.Replace("@","ATTHERATE").Replace(".","DOT").ToUpper(),
                Email = userModel.Email,
                Password = userModel.Password,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
            };
            _repository.Add(userDbModel);
            return "SUCCESS";
        }
    }
}
