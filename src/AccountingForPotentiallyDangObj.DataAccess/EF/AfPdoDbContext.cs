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
        public DbSet<TypeOfPdo> TypeOfPdo { get; set; }
        public DbSet<JournalPDO> JournalPDO { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<InstallationLocation> InstallationLocation { get; set; }
        public DbSet<TechnicalConditional> TechnicalConditional { get; set; }
        public DbSet<TechnicalSpecification> TechnicalSpecification { get; set; }
        public DbSet<DepartmentalAffiliation> DepartmentalAffiliation { get; set; }
        public DbSet<PDO> PDO { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

    }
}
