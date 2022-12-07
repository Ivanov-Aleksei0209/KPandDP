using AccountingForPotentiallyDangObj.DataAccess.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace AccountingForPotentiallyDangObj.DataAccess.EF
{
    public class AfPdoDbContext : DbContext
    {
        private readonly string _connectionString;

        public AfPdoDbContext()
        {
        }

        public AfPdoDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DbSet<Inspector> Inspector { get; set; }
        // аналогично для других таблиц

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

    }
}
