using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using AccountingForPotentiallyDangObj.Web.Models;
using AccountingForPotentiallyDangObj.Web.Helpers;
using Microsoft.CodeAnalysis;

namespace AccountingForPotentiallyDangObj.Web.Services
{
    public class PdoService : IPdoService
    {
        private readonly IRepository<Pdo> _repositoryPdo;
        private readonly ITechnicalSpecificationService _technicalSpecificationService;
        private readonly IRepository<JournalPdo> _repositoryJournalPdo;
        private readonly IRepository<TypeOfPdo> _repositoryTypeOfPdo;
        private readonly IRepository<TechnicalConditional> _repositoryTechnicalConditional;
        private readonly IRepository<Inspector> _repositoryInspector;
        private readonly IRepository<Subject> _repositorySubject;
        private readonly IRepository<InstallationLocation> _repositoryInstallationLocation;
        private readonly IRepository<TechnicalSpecification> _repositoryTechnicalSpecification;
        private readonly IMapperConfig _mapperConfig;
        private readonly IPdoHelper _pdoHelper;

        public PdoService(IRepository<Pdo> repositoryPdo, ITechnicalSpecificationService technicalSpecificationService, IRepository<JournalPdo> repositoryJournalPdo, IRepository<TypeOfPdo> repositoryTypeOfPdo, IRepository<TechnicalConditional> repositoryTechnicalConditional,
            IRepository<Inspector> repositoryInspector, IRepository<Subject> repositorySubject, IRepository<InstallationLocation> repositoryInstallationLocation,
            IRepository<TechnicalSpecification> repositoryTechnicalSpecification, IMapperConfig mapperConfig, IPdoHelper pdoHelper)
        {
            _repositoryPdo = repositoryPdo;
            _technicalSpecificationService = technicalSpecificationService;
            _repositoryJournalPdo = repositoryJournalPdo;
            _repositoryTypeOfPdo = repositoryTypeOfPdo;
            _repositoryTechnicalConditional = repositoryTechnicalConditional;
            _repositoryInspector = repositoryInspector;
            _repositorySubject = repositorySubject;
            _repositoryInstallationLocation = repositoryInstallationLocation;
            _repositoryTechnicalSpecification = repositoryTechnicalSpecification;
            _mapperConfig = mapperConfig;
            _pdoHelper = pdoHelper;
        }
        //public PdoService() { }

        public IEnumerable<PdoDto> GetAllPdoAsync()
        {
            var models = _repositoryPdo.GetAll();
            var modelsJournalPdo = models.Select(x => x.JournalPdo).ToList(); //_repositoryJournalPdo.GetAll();
            var modelsTypeOfPdo = models.Select(x => x.Type).ToList(); //_repositoryTypeOfPdo.GetAll();
            var modelsTechnicalConditional = models.Select(x => x.TechnicalConditional).ToList(); //_repositoryTechnicalConditional.GetAll();
            var modelsInspector = models.Select(x => x.Inspector).ToList();//_repositoryInspector.GetAll();
            var modelsSubject = models.Select(x => x.Subject).ToList(); //_repositorySubject.GetAll();
            var modelsDto = _mapperConfig.Mapper.Map<IEnumerable<PdoDto>>(models);
            foreach (var modelDto in modelsDto)
            {
                var journalPdoById = modelsJournalPdo.Where(x => x.Id == modelDto.JournalPdoId).FirstOrDefault();
                var typeOfPdoById = modelsTypeOfPdo.Where(x => x.Id == modelDto.TypeId).FirstOrDefault();
                var techCondModelById = modelsTechnicalConditional.Where(x => x.Id == modelDto.TechnicalConditionalId).FirstOrDefault();
                var inspectorById = modelsInspector.Where(x => x.Id == modelDto.InspectorId).FirstOrDefault();
                var subjectById = modelsSubject.Where(x => x.Id == modelDto.SubjectId).FirstOrDefault();

                modelDto.JournalNumber = journalPdoById.JournalNumber;
                modelDto.TypeName = typeOfPdoById.Abb;
                modelDto.TechnicalConditionalName = techCondModelById.Name;
                modelDto.InspectorName = inspectorById.Name;
                modelDto.SubjectName = subjectById.Name;
            }
            return modelsDto;
        }

        public IEnumerable<ReportPdoDto> GetReportPdo()
        {

            var reportPdoDto = new List<ReportPdoDto>();
            List<int> journalsId = new List<int>();
            journalsId = _repositoryJournalPdo.GetAll().Select(x => x.Id).ToList();

            foreach (var journalIdItem in journalsId)
            {

                JournalPdo journalPdo = _repositoryJournalPdo.GetAll().Where(x => x.Id == journalIdItem).FirstOrDefault();
                int journalPdoId = _repositoryJournalPdo.GetAll().Where(x => x.Id == journalIdItem).Select(x => x.Id).FirstOrDefault();

                var pdoModels = _repositoryPdo.GetAll().Where(x => x.JournalPdoId == journalPdoId).ToList();

                var notWithdrawalFromRegistrationModels = _pdoHelper.GetNotWithdrawalFromRegistration(pdoModels, journalPdoId);
                var oldPdoModel = _pdoHelper.GetOldPdoModel(pdoModels, journalPdoId);

                var pdoDtoModel = new ReportPdoDto()
                {
                    Quantity = notWithdrawalFromRegistrationModels.Count(),
                    QuantityOld = oldPdoModel.Count(),
                    NameJournal = journalPdo.Name,
                    PercentOld = _pdoHelper.GetPercentOld(notWithdrawalFromRegistrationModels.Count(), oldPdoModel.Count())
                };
                pdoDtoModel.QuantityAll = pdoDtoModel.Quantity;
                pdoDtoModel.QuantityAllOld = pdoDtoModel.QuantityOld;
                pdoDtoModel.PercentAllOld = _pdoHelper.GetPercentOld(reportPdoDto.Select(x => x.QuantityAll).Sum(), reportPdoDto.Select(x => x.QuantityAllOld).Sum());
                reportPdoDto.Add(pdoDtoModel);

                List<int> typesId = new List<int>();
                typesId = notWithdrawalFromRegistrationModels.Select(x => x.TypeId).Distinct().ToList();

                foreach (var typeIdItem in typesId)
                {
                    var pdoDtoModelByTypes = new ReportPdoDto();
                    var modelsByType = notWithdrawalFromRegistrationModels.Where(x => x.TypeId == typeIdItem).ToList();
                    var modelsOldByType = oldPdoModel.Where(x => x.TypeId == typeIdItem).ToList();
                    pdoDtoModelByTypes.NameType = _repositoryTypeOfPdo.GetAll().Where(x => x.Id == typeIdItem).Select(x => x.Name).FirstOrDefault();
                    pdoDtoModelByTypes.Quantity = modelsByType.Count();
                    pdoDtoModelByTypes.QuantityOld = modelsOldByType.Count();
                    pdoDtoModelByTypes.PercentOld = _pdoHelper.GetPercentOld(modelsByType.Count(), modelsOldByType.Count());
                    reportPdoDto.Add(pdoDtoModelByTypes);
                }
            }
            return reportPdoDto;
        }
        
        public async Task<PdoDto> CreatePdoAsync(PdoDto modelDto)
        {

            var model = _mapperConfig.Mapper.Map<Pdo>(modelDto);

            model = await _repositoryPdo.CreateAsync(model);

            modelDto = _mapperConfig.Mapper.Map<PdoDto>(model);

            return modelDto;
        }

        
        public async Task<PdoDto> UpdatePdoAsync(PdoDto modelDto)
        {

            var model = _mapperConfig.Mapper.Map<Pdo>(modelDto);

            model = await _repositoryPdo.UpdateAsync(model);

            modelDto = _mapperConfig.Mapper.Map<PdoDto>(model);

            return modelDto;
        }
    }
}
