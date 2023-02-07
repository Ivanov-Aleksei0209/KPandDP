using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingForPotentiallyDangObj.DataAccess.Infrastructure
{
    public class DataAccessModule : Module
    {
        private readonly string _connectionString;

        public DataAccessModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AfPdoRepository<Inspector>>().As<IRepository<Inspector>>();
            builder.RegisterType<AfPdoRepository<JournalPDO>>().As<IRepository<JournalPDO>>();

            builder.RegisterType<AfPdoDbContext>().As<AfPdoDbContext>().WithParameter("connectionString", _connectionString);
        }
    }
}
