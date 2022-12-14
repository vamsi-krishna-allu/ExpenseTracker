using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Context
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options)
        {

        }

        public DbSet<ExpenseDbModel> ExpenseDbModels => Set<ExpenseDbModel>();

        public DbSet<UserDbModel> UserDbModels => Set<UserDbModel>();

    }
}
