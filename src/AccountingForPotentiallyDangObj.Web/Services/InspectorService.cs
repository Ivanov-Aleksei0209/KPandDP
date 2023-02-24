using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;

namespace AccountingForPotentiallyDangObj.Web.Service
{
    public class InspectorService : IInspectorService
    {
        private readonly IRepository<Inspector> _repositoryInspector;
        private readonly IMapperConfig _mapperConfig;

        public InspectorService(IRepository<Inspector> repositoryInspector, IMapperConfig mapperConfig)
        {
            _repositoryInspector = repositoryInspector;
            _mapperConfig = mapperConfig;
        }

        public IEnumerable<InspectorDto> GetAllAsync()
        {
            var models = _repositoryInspector.GetAll();
            var modelsDto = _mapperConfig.Mapper.Map<IEnumerable<InspectorDto>>(models);
            return modelsDto;
        }
               
    }
}
