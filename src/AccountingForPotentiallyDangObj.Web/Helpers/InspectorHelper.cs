using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using AccountingForPotentiallyDangObj.Web.Models;

namespace AccountingForPotentiallyDangObj.Web.Helpers
{
    public class InspectorHelper : IInspectorHelper
    {
        private readonly IRepository<Inspector> _repositoryInspector;
        private readonly IRepository<Role> _repositoryRole;
        private readonly IMapperConfig _mapperConfig;

        public InspectorHelper(IRepository<Inspector> repositoryInspector, IRepository<Role> repositoryRole, IMapperConfig mapperConfig)
        {
            _repositoryInspector = repositoryInspector;
            _repositoryRole = repositoryRole;
            _mapperConfig = mapperConfig;
        }

        public async Task<InspectorDto> GetInspectorDtoForCreate(InspectorViewModel model)
        {
            var resultModel = _mapperConfig.Mapper.Map<InspectorDto>(model);

            var modelsRole = _repositoryRole.GetAll();
            var roleById = modelsRole.Where(x => x.Name == model.RoleName).FirstOrDefault();
            resultModel.RoleId = roleById.Id;

            return resultModel;
        }

        public async Task<InspectorDto> GetInspectorDtoByIdAsync(int id)
        {
            var modelById = await _repositoryInspector.GetByIdAsync(id);
            
            var modelsRole = _repositoryRole.GetAll();
            
            var modelDto = _mapperConfig.Mapper.Map<InspectorDto>(modelById);

            var roleById = modelsRole.Where(x => x.Id == modelDto.RoleId).FirstOrDefault();

            modelDto.RoleName = roleById.Name;
           
            return modelDto;

        }

        public async Task<InspectorDto> GetInspectorDtoForUpdateAsync(InspectorViewModel model)
        {

            var resultModel = _mapperConfig.Mapper.Map<InspectorDto>(model);

            var modelsRole = _repositoryRole.GetAll();
            var roleById = modelsRole.Where(x => x.Name == model.RoleName).FirstOrDefault();
            resultModel.RoleId = roleById.Id;
            
            return resultModel;
        }
    }
}
