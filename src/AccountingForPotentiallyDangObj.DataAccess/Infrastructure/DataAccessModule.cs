﻿using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
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
            builder.RegisterType<AfPdoRepository<JournalPdo>>().As<IRepository<JournalPdo>>();
            builder.RegisterType<AfPdoRepository<Pdo>>().As<IRepository<Pdo>>();
            builder.RegisterType<AfPdoRepository<TechnicalConditional>>().As<IRepository<TechnicalConditional>>();
            builder.RegisterType<AfPdoRepository<Inspector>>().As<IRepository<Inspector>>();
            builder.RegisterType<AfPdoRepository<TypeOfPdo>>().As<IRepository<TypeOfPdo>>();
            builder.RegisterType<AfPdoRepository<Subject>>().As<IRepository<Subject>>();
            builder.RegisterType<AfPdoRepository<DepartmentalAffiliation>>().As<IRepository<DepartmentalAffiliation>>();
            builder.RegisterType<AfPdoRepository<Role>>().As<IRepository<Role>>();
            builder.RegisterType<AfPdoRepository<InstallationLocation>>().As<IRepository<InstallationLocation>>();
            builder.RegisterType<AfPdoRepository<TechnicalSpecification>>().As<IRepository<TechnicalSpecification>>();
            builder.RegisterType<AfPdoDbContext>().As<AfPdoDbContext>().WithParameter("connectionString", _connectionString);
        }
    }
}
