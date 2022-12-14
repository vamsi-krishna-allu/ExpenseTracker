using Database.Context;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class UserRepository : IRepository<UserDbModel>
    {
        private readonly ExpenseContext userContext;

        public UserRepository(ExpenseContext userContext)
        {
            this.userContext = userContext;
        }
        public void Add(UserDbModel item)
        {
            userContext.Add(item);
            userContext.SaveChanges();
        }

        public bool Exists(string id)
        {
            return userContext.UserDbModels.Any(e => e.Email == id);
        }

        public List<UserDbModel> Find(Expression<Func<UserDbModel, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public UserDbModel? Get(string? id)
        {
            return userContext.UserDbModels.FirstOrDefault(m => m.Email == id);
        }

        public List<UserDbModel> GetAll()
        {
            return userContext.UserDbModels.ToList();
        }

        public void Remove(string id)
        {
            var user = userContext.UserDbModels.Find(id);
            if (user != null)
            {
                userContext.UserDbModels.Remove(user);
                userContext.SaveChanges();
            }
        }

        public UserDbModel Update(UserDbModel item)
        {
            userContext.Update(item);
            userContext.SaveChanges();
            return item;
        }
    }
}
