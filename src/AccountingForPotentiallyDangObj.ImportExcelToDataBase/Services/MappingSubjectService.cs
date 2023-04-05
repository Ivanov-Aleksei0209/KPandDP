using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.DtoModels;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.Services
{
    public class MappingSubjectService
    {
        private readonly IRepository<Subject> _repositorySubject;
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        
        public MappingSubjectService()
        {
            var dbContext = new AfPdoDbContext(_connectionString);
            _repositorySubject = new AfPdoRepository<Subject>(dbContext);
        }

        public List<SubjectExcelModel> MapJObjectsToSubjectExcelModels(JObject jObject)
        {
            var jObjectChildrenArray = jObject["2022.12.02 Список ПОО"];

            var subjectsExcelModel = jObjectChildrenArray.Select(x => new SubjectExcelModel
            {
                Subject = (string)x["Subject"],
                UNP = (string)x["UNP"],
                PostalAddress = (string)x["PostalAddress"],
                Phone = (string)x["Phone"]
            }).ToList();

            return subjectsExcelModel;
        }
        

        public List<SubjectDto> MapSubjectExelModelsToSubjectsDto(List<SubjectExcelModel> subjectsExcelModel)
        {
            var subjectsDtoModel = new List<SubjectDto>();
            foreach (var item in subjectsExcelModel)
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
        public Subject MapSubjectDtoToSubjectModel(SubjectDto subjectDtoModel)
        {
            var model = new Subject();
            var modelsPdo = _repositorySubject.GetAll().ToList();
            if (modelsPdo.Select(x => x.Name).Contains(subjectDtoModel.Subject))
            {
                model.Name = null;
                Console.WriteLine($"Субъект {subjectDtoModel.Subject} уже существует");
            }
            else
            {
                model.Name = subjectDtoModel.Subject;
                model.UNP = Convert.ToInt32(subjectDtoModel.UNP);
                model.PostalAddress = subjectDtoModel.PostalAddress;
                model.Phone = subjectDtoModel.Phone;
            }
            return model;
        }

        public List<Subject> MapSubjectDtoModelsToSubjectModels(List<SubjectDto> subjectsDtoModel)
        {
            var models = new List<Subject>();
            foreach (SubjectDto subjectDto in subjectsDtoModel)
            {
                var model = MapSubjectDtoToSubjectModel(subjectDto);
                if (model.Name != null)
                models.Add(model);
            }
            return models;
        }
    }
}
