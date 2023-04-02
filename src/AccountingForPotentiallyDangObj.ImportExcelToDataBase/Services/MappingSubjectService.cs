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
            var model = new Subject()
            {
                Name = subjectDtoModel.Subject,
                UNP = Convert.ToInt32(subjectDtoModel.UNP),
                PostalAddress = subjectDtoModel.PostalAddress,
                Phone = subjectDtoModel.Phone
            };
            return model;
        }
        public List<Subject> MapSubjectDtoModelsToSubjectModels(List<SubjectDto> subjectsDtoModel)
        {
            var models = new List<Subject>();
            foreach (SubjectDto subjectDto in subjectsDtoModel)
            {
                var model = MapSubjectDtoToSubjectModel(subjectDto);
                models.Add(model);
            }
            return models;
        }
        

    }
}
