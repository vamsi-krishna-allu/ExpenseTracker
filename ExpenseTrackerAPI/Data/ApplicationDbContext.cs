using ExpenseTracker.Models;
using System.Data.Entity;

namespace ExpenseTrackerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public DbSet<ExpenseModelDb> ExpenseModels => Set<ExpenseModelDb>();

        public DbSet<UserModelDb> UserModels => Set<UserModelDb>();
    }
}
