using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;

namespace AccountingForPotentiallyDangObj.Web.Services
{
    public class PdoService : IPdoService
    {
        private readonly IRepository<Pdo> _repositoryPdo;
        private readonly IRepository<TechnicalConditional> _repositoryTechnicalConditional;
        private readonly IMapperConfig _mapperConfig;

        public PdoService(IRepository<Pdo> repositoryPdo, IRepository<TechnicalConditional> repositoryTechnicalConditional, IMapperConfig mapperConfig)
        {
            _repositoryPdo = repositoryPdo;
            _repositoryTechnicalConditional = repositoryTechnicalConditional;
            _mapperConfig = mapperConfig;
        }

        public IEnumerable<PdoDto> GetAllAsync() 
        {
            var models = _repositoryPdo.GetAll();
            var modelsTechnicalConditional = _repositoryTechnicalConditional.GetAll();
            var modelsDto = _mapperConfig.Mapper.Map<IEnumerable<PdoDto>>(models);
            foreach (var modelDto in modelsDto) 
            {
                var techCondModelById = modelsTechnicalConditional.Where(x => x.Id == modelDto.TechnicalConditionalId).FirstOrDefault();
                modelDto.TechnicalConditionalName = techCondModelById.Name;
            }
            return modelsDto;
        }

    }
}
