using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.DtoModels;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.Interfaces;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.Infrastructure;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using Newtonsoft.Json.Linq;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.Services
{
    public class SubjectService
    {
        private readonly IRepository<Subject> _repositorySubject;
        private readonly IRepository<DepartmentalAffiliation> _repositoryDepartmentalAffilation;
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public SubjectService()
        {
            var dbContext = new AfPdoDbContext(_connectionString);
            _repositorySubject = new AfPdoRepository<Subject>(dbContext);
        }
        


        
        
        public async Task<List<Subject>> AddSubjectAsync(List<Subject> subjectsModel)
        {          
            foreach (var subjectModel in subjectsModel)
            {
                
                await _repositorySubject.CreateAsync(subjectModel);  
               
            }
            return subjectsModel;
        }

       
    }
 }
