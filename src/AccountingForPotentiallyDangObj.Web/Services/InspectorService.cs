using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using AccountingForPotentiallyDangObj.Web.Models;

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

        public async Task<InspectorDto> MapInspectorViewModelToInspectorDto(InspectorViewModel model)
        {
            var resultModel = _mapperConfig.Mapper.Map<InspectorDto>(model);

            var modelsRole = _repositoryRole.GetAll();
            var roleById = modelsRole.Where(x => x.Name == model.RoleName).FirstOrDefault();
            resultModel.RoleId = roleById.Id;

            return resultModel;
        }
        public async Task<InspectorDto> AddNewInspectorAsync(InspectorDto modelDto)
        {
            var model = _mapperConfig.Mapper.Map<Inspector>(modelDto);

            model = await _repositoryInspector.CreateAsync(model);

            modelDto = _mapperConfig.Mapper.Map<InspectorDto>(model);

            return modelDto;
        }
    }
}
