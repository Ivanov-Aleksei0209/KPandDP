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

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> _repositorySubject;
        private readonly IRepository<DepartmentalAffiliation> _repositoryDepartmentalAffilation;
        private readonly IMapperConfig _mapperConfig;

        public SubjectService(IRepository<Subject> repositorySubject, IRepository<DepartmentalAffiliation> repositoryDepartmentalAffilation,
            IMapperConfig mapperConfig)
        {
            _repositorySubject = repositorySubject;
            _repositoryDepartmentalAffilation = repositoryDepartmentalAffilation;
            _mapperConfig = mapperConfig;
        }
        public SubjectService() { }

        public void AddAllSubjectAsync(List<SubjectDto> subjectsDtoModel)
        {
            foreach (var subjectDto in subjectsDtoModel)
            {
                var model = new Subject();
                
                model = _mapperConfig.Mapper.Map<Subject>(subjectDto);
                _repositorySubject.AddAsync(model);
            }
        }

        public List<SubjectDto> GetSubjectFrom(List<SubjectExcelModel> jsonObjectChildrenList)
        {

            var subjectsDtoModel = new List<SubjectDto>();
            foreach (var item in jsonObjectChildrenList)
            {
                var subjectDtoModel = new SubjectDto();
                subjectDtoModel.Subject = jsonObjectChildrenList.Select(x => item.Subject).FirstOrDefault();
                subjectDtoModel.UNP = jsonObjectChildrenList.Select(x => item.UNP).FirstOrDefault();
                subjectDtoModel.PostalAddress = jsonObjectChildrenList.Select(x => item.PostalAddress).FirstOrDefault();
                subjectDtoModel.Phone = jsonObjectChildrenList.Select(x => item.Phone).FirstOrDefault();
                
                subjectsDtoModel.Add(subjectDtoModel);
            }

            return subjectsDtoModel;
        }
    }
 }
