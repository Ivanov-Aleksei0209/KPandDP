using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;

namespace AccountingForPotentiallyDangObj.Web.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> _repositorySubject;
        private readonly IMapperConfig _mapperConfig;

        public SubjectService(IRepository<Subject> repositorySubject, IMapperConfig mapperConfig)
        {
            _repositorySubject = repositorySubject;
            _mapperConfig = mapperConfig;
        }

        public IEnumerable<SubjectDto> GetAllSubjectAsync()
        {
            var models = _repositorySubject.GetAll();
            var modelsDto = _mapperConfig.Mapper.Map<IEnumerable<SubjectDto>>(models);
            return modelsDto;
        }
    }
}
