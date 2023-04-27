using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;

namespace AccountingForPotentiallyDangObj.Web.Services
{
    public class DepartmentalAffiliationService : IDepartmentalAffiliationService
    {
        private readonly IRepository<DepartmentalAffiliation> _repositoryDepartmentalAffiliation;
        private readonly IMapperConfig _mapperConfig;

        public DepartmentalAffiliationService(IRepository<DepartmentalAffiliation> repositoryDepartmentalAffiliation, IMapperConfig mapperConfig)
        {
            _repositoryDepartmentalAffiliation = repositoryDepartmentalAffiliation;
            _mapperConfig = mapperConfig;
        }

        public IEnumerable<DepartmentalAffiliationDto> GetAllAsync()
        {
            var models = _repositoryDepartmentalAffiliation.GetAll();
            var modelsDto = _mapperConfig.Mapper.Map<IEnumerable<DepartmentalAffiliationDto>>(models);
            return modelsDto;

        }
    }
}
