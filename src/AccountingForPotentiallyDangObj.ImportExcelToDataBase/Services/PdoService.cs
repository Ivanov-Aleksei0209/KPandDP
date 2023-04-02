using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.Services
{
    public class PdoService
    {
        private readonly IRepository<Pdo> _repositoryPdo;
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public PdoService()
        {
            var dbContext = new AfPdoDbContext(_connectionString);
            _repositoryPdo = new AfPdoRepository<Pdo>(dbContext);
        }


        public async Task<List<Pdo>> AddPdoAsync(List<Pdo> PdoModels)
        {
            foreach (var PdoModel in PdoModels)
            {

                await _repositoryPdo.AddAsync(PdoModel);

            }
            return PdoModels;
        }
    }
}
