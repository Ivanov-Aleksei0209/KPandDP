using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;

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
                var departmentalAffilationById = modelsDepertmentalAffiliation.Where(x => x.Id == modelDto.departmentalAffiliationId).FirstOrDefault();
                modelDto.departmentalAffiliationName = departmentalAffilationById.Name;
            }
            return modelsDto;
        }
        
    }
}
