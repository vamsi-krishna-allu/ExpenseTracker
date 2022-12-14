using Database.Context;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class ExpenseRepository : IRepository<ExpenseDbModel>
    {
        private readonly ExpenseContext expenseContext;

        public ExpenseRepository(ExpenseContext expenseContext)
        {
            this.expenseContext = expenseContext;
        }
        public void Add(ExpenseDbModel item)
        {
            expenseContext.Add(item);
            expenseContext.SaveChanges();
        }

        public bool Exists(string id)
        {
            return expenseContext.ExpenseDbModels.Any(e => e._id == id);
        }

        public List<ExpenseDbModel> Find(Expression<Func<ExpenseDbModel, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ExpenseDbModel? Get(string? id)
        {
            return expenseContext.ExpenseDbModels.FirstOrDefault(m => m._id == id);
        }

        public List<ExpenseDbModel> GetAll()
        {
            return expenseContext.ExpenseDbModels.ToList();
        }

        public void Remove(string id)
        {
            var expense = expenseContext.ExpenseDbModels.Find(id);
            if (expense != null)
            {
                expenseContext.ExpenseDbModels.Remove(expense);
                expenseContext.SaveChanges();
            }
        }

        public ExpenseDbModel Update(ExpenseDbModel item)
        {
            expenseContext.Update(item);
            expenseContext.SaveChanges();
            return item;
        }
    }
}
