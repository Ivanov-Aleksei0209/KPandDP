using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using AccountingForPotentiallyDangObj.Web.Models;

namespace AccountingForPotentiallyDangObj.Web.Services
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

        public IEnumerable<SubjectDto> GetAllSubjectAsync()
        {
            var models = _repositorySubject.GetAll();
            var modelsDepertmentalAffiliation = _repositoryDepartmentalAffilation.GetAll();
            var modelsDto = _mapperConfig.Mapper.Map<IEnumerable<SubjectDto>>(models);

            foreach (var modelDto in modelsDto)
            {
                var departmentalAffilationById = modelsDepertmentalAffiliation.Where(x => x.Id == modelDto.DepartmentalAffiliationId).FirstOrDefault();
                if (departmentalAffilationById != null)
                {
                    modelDto.DepartmentalAffiliationName = departmentalAffilationById.Name;
                }
                
            }
            return modelsDto;
        }
        public async Task<SubjectDto> MapSubjectViewModelToSubjectDto(SubjectViewModel model)
        {
            var resultModel = _mapperConfig.Mapper.Map<SubjectDto>(model);

            var modelsDepartmentalAffiliation = _repositoryDepartmentalAffilation.GetAll();
            var departmentalAffilationById = modelsDepartmentalAffiliation.Where(x => x.Name == model.DepartmentalAffiliationName).FirstOrDefault();
            resultModel.DepartmentalAffiliationId = departmentalAffilationById.Id;

            return resultModel;
        }
        public async Task<SubjectDto> AddNewSubjectAsync(SubjectDto modelDto)
        {
            var subjectModel = _mapperConfig.Mapper.Map<Subject>(modelDto);

            subjectModel = await _repositorySubject.CreateAsync(subjectModel);

            modelDto = _mapperConfig.Mapper.Map<SubjectDto>(subjectModel);

            return modelDto;
        }

        //public async Task<SubjectDto> EditSubjectAsync(int id)
        //{
        //    var modelById = await _repositorySubject.GetByIdAsync(id);

        //    var model = _mapperConfig.Mapper.Map<Subject>(modelDto);

        //    model = await _repositorySubject.UpdateAsync(model);

        //    modelDto = _mapperConfig.Mapper.Map<SubjectDto>(model);

        //    return modelDto;
        //}

    }
}
