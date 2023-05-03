using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using AccountingForPotentiallyDangObj.Web.Models;

namespace AccountingForPotentiallyDangObj.Web.Helpers
{
    public class SubjectHelper : ISubjectHelper
    {
        private readonly IRepository<Subject> _repositorySubject;
        private readonly IRepository<DepartmentalAffiliation> _repositoryDepartmentalAffiliation;
        private readonly IMapperConfig _mapperConfig;

        public SubjectHelper(IRepository<Subject> repositorySubject, IRepository<DepartmentalAffiliation> repositoryDepartmentalAffiliation, IMapperConfig mapperConfig)
        {
            _repositorySubject = repositorySubject;
            _repositoryDepartmentalAffiliation = repositoryDepartmentalAffiliation;
            _mapperConfig = mapperConfig;
        }

        public async Task<SubjectDto> GetSubjectDtoForCreate(SubjectViewModel model)
        {
            var resultModel = _mapperConfig.Mapper.Map<SubjectDto>(model);

            var modelsDepartmentalAffiliation = _repositoryDepartmentalAffiliation.GetAll();
            var departmentalAffiliationById = modelsDepartmentalAffiliation.Where(x => x.Name == model.DepartmentalAffiliationName).FirstOrDefault();
            resultModel.DepartmentalAffiliationId = departmentalAffiliationById.Id;

            return resultModel;
        }

        public async Task<SubjectDto> GetSubjectDtoByIdAsync(int id)
        {
            var modelById = await _repositorySubject.GetByIdAsync(id);

            var modelsDepartmentalAffiliation = _repositoryDepartmentalAffiliation.GetAll();

            var modelDto = _mapperConfig.Mapper.Map<SubjectDto>(modelById);

            var departmentalAffiliationById = modelsDepartmentalAffiliation.Where(x => x.Id == modelDto.DepartmentalAffiliationId).FirstOrDefault();

            if (departmentalAffiliationById != null)
            modelDto.DepartmentalAffiliationName = departmentalAffiliationById.Name;

            return modelDto;

        }

        public async Task<SubjectDto> GetSubjectDtoForUpdateAsync(SubjectViewModel model)
        {

            var resultModel = _mapperConfig.Mapper.Map<SubjectDto>(model);

            var modelsDepartmentalAffiliation = _repositoryDepartmentalAffiliation.GetAll();
            var departmentalAffiliationById = modelsDepartmentalAffiliation.Where(x => x.Name == model.DepartmentalAffiliationName).FirstOrDefault();
            resultModel.DepartmentalAffiliationId = departmentalAffiliationById.Id;

            return resultModel;
        }
    }
}

