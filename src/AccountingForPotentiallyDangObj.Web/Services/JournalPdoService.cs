using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;

namespace AccountingForPotentiallyDangObj.Web.Services
{
    public class JournalPdoService : IJournalPdoService
    {
        private readonly IRepository<JournalPdo> _repositoryJournalPdo;
        private readonly IMapperConfig _mapperConfig;

        public JournalPdoService(IRepository<JournalPdo> repositoryJournalPDO, IMapperConfig mapperConfig)
        {
            _repositoryJournalPdo = repositoryJournalPDO;
            _mapperConfig = mapperConfig;
        }

        public IEnumerable<JournalPdoDto> GetAllAsync()
        {
            var models = _repositoryJournalPdo.GetAll();
            var modelsDto = _mapperConfig.Mapper.Map<IEnumerable<JournalPdoDto>>(models);
            return modelsDto;

        }
    }
}
