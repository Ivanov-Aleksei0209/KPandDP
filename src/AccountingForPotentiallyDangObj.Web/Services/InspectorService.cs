using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;

namespace AccountingForPotentiallyDangObj.Web.Services
{
    public class InspectorService : IInspectorService
    {
        private readonly IRepository<Inspector> _repositoryInspector;
        private readonly IRepository<Role> _repositoryRole;
        private readonly IMapperConfig _mapperConfig;

        public InspectorService(IRepository<Inspector> repositoryInspector, IRepository<Role> repositoryRole, IMapperConfig mapperConfig)
        {
            _repositoryInspector = repositoryInspector;
            _repositoryRole = repositoryRole;
            _mapperConfig = mapperConfig;
        }

        public IEnumerable<InspectorDto> GetAllInspectorAsync()
        {
            var models = _repositoryInspector.GetAll();
            var modelsRole = _repositoryRole.GetAll();
            var modelsDto = _mapperConfig.Mapper.Map<IEnumerable<InspectorDto>>(models);

            foreach (var modelDto in modelsDto)
            {
                var RoleById = modelsRole.Where(x => x.Id == modelDto.RoleId).FirstOrDefault();
                if (RoleById != null)
                {
                    modelDto.Role = RoleById.Name;
                }

            }
            return modelsDto;
        }
    }
}
