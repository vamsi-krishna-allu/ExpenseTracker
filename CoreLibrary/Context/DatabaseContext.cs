using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DbSet<ExpenseModelDb> ExpenseModels =>  Set<ExpenseModelDb>();

        public DbSet<UserModelDb> UserModels => Set<UserModelDb>();

    }
}
