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

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.Services
{
    public class SubjectService
    {
        private readonly IRepository<Subject> _repositorySubject;
        private readonly IRepository<DepartmentalAffiliation> _repositoryDepartmentalAffilation;
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //private readonly IMapperConfig _mapperConfig;

        public SubjectService()
        {
            var dbContext = new AfPdoDbContext(_connectionString);
            _repositorySubject = new AfPdoRepository<Subject>(dbContext);
            //_repositoryDepartmentalAffilation = repositoryDepartmentalAffilation;
            //_mapperConfig = new MapperConfig(new MapperProfile());

        }
        

        public Subject MapDtoToModel(SubjectDto subjectDtoModel)
        {
            var model = new Subject()
            {
                Name = subjectDtoModel.Subject,
                UNP = Convert.ToInt32(subjectDtoModel.UNP),
                PostalAddress = subjectDtoModel.PostalAddress,
                Phone = subjectDtoModel.Phone
            };
            return model;
        }
        public List<Subject> MapDtoModelsToModels(List<SubjectDto> subjectDtoModels)
        {
            var models = new List<Subject>();
            foreach (SubjectDto subjectDto in subjectDtoModels)
            {
                var model = MapDtoToModel(subjectDto);
                models.Add(model);
            }
            return models;
        }
        
        public async Task<List<Subject>> AddAllSubjectAsync(List<Subject> models)
        {          
            foreach (var model in models)
            {
                
                var tempModel = await _repositorySubject.AddAsync(model);  
               
            }
            return models;
        }

        public List<SubjectDto> GetSubjectFrom(List<SubjectExcelModel> jsonObjectChildrenList)
        {

            var subjectsDtoModel = new List<SubjectDto>();
            foreach (var item in jsonObjectChildrenList)
            {
                var subjectDtoModel = new SubjectDto();
                subjectDtoModel.Subject = item.Subject;
                subjectDtoModel.UNP = item.UNP;
                subjectDtoModel.PostalAddress = item.PostalAddress;
                subjectDtoModel.Phone = item.Phone;
                
                subjectsDtoModel.Add(subjectDtoModel);
            }

            return subjectsDtoModel;
        }
    }
 }
