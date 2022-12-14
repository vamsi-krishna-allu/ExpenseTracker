using CoreLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
         : base(options)
        {

        }

        public DbSet<ExpenseModelDb> ExpenseModels =>  Set<ExpenseModelDb>();

        public DbSet<UserModelDb> UserModels => Set<UserModelDb>();

    }
}
