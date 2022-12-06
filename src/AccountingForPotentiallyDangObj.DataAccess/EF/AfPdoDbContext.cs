using AccountingForPotentiallyDangObj.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public DbSet<Inspectors> Inspectors { get; set; }
        // аналогично для других таблиц


    }
}
