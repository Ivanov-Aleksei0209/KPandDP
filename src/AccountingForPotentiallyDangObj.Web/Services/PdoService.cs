using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using Microsoft.CodeAnalysis;

namespace AccountingForPotentiallyDangObj.Web.Services
{
    public class PdoService : IPdoService
    {
        private readonly IRepository<Pdo> _repositoryPdo;
        private readonly IRepository<JournalPdo> _repositoryJournalPdo;
        private readonly IRepository<TypeOfPdo> _repositoryTypeOfPdo;
        private readonly IRepository<TechnicalConditional> _repositoryTechnicalConditional;
        private readonly IRepository<Inspector> _repositoryInspector;
        private readonly IRepository<Subject> _repositorySubject;
        private readonly IMapperConfig _mapperConfig;

        public PdoService(IRepository<Pdo> repositoryPdo, IRepository<JournalPdo> repositoryJournalPdo, IRepository<TypeOfPdo> repositoryTypeOfPdo, IRepository<TechnicalConditional> repositoryTechnicalConditional,
            IRepository<Inspector> repositoryInspector, IRepository<Subject> repositorySubject, IMapperConfig mapperConfig)
        {
            _repositoryPdo = repositoryPdo;
            _repositoryJournalPdo = repositoryJournalPdo;
            _repositoryTypeOfPdo = repositoryTypeOfPdo;
            _repositoryTechnicalConditional = repositoryTechnicalConditional;
            _repositoryInspector = repositoryInspector;
            _repositorySubject = repositorySubject;
            _mapperConfig = mapperConfig;
        }

        public IEnumerable<PdoDto> GetAllPdoAsync()
        {
            var models = _repositoryPdo.GetAll();
            var modelsJournalPdo = _repositoryJournalPdo.GetAll();
            var modelsTypeOfPdo = _repositoryTypeOfPdo.GetAll();
            var modelsTechnicalConditional = _repositoryTechnicalConditional.GetAll();
            var modelsInspector = _repositoryInspector.GetAll();
            var modelsSubject = _repositorySubject.GetAll();
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
            
            // метод подсчета ПОО не снятых с учета
            List<Pdo> GetNotWithdrawalFromRegistration(List<Pdo> models, int journalPdoId)
            {
                var tempCollectionModels = new List<Pdo>();
                for (var i = 0; i < models.Count(); i++)
                {
                    var pdoModel = models[i];
                    if (pdoModel.JournalPdoId == journalPdoId && pdoModel.WithdrawalFromRegistration == null)
                        tempCollectionModels.Add(pdoModel);
                        
                }
                return tempCollectionModels;
            }
            // метод подсчета ПОО, отработавших назначенный срок службы
            List<Pdo> GetOldPdoModel(List<Pdo> models, int journalPdoId)
            {
                var tempCollectionModels = new List<Pdo>();
                for (var i = 0; i < models.Count(); i++)
                {
                    var pdoModel = models[i];
                    if (pdoModel.JournalPdoId == journalPdoId && DateTime.Now.Year - pdoModel.YearOfManufacture > pdoModel.ServiceLife && pdoModel.WithdrawalFromRegistration == null)
                        tempCollectionModels.Add(pdoModel);
                }
                return tempCollectionModels;
            }
            // метод подсчета процента ПОО отработавших НСС
            double GetPercentOld(int notWithdrawalFromRegistration, int oldPdo)
            {
                double percentOld;
                if (notWithdrawalFromRegistration != 0)
                {
                    percentOld = Math.Round((double)oldPdo / (double)notWithdrawalFromRegistration * 100, 1);
                }
                else { percentOld = 0; }

                return percentOld;
            }

            var reportPdoDto = new List<ReportPdoDto>();
            List<int> journalsId = new List<int>();
            journalsId = _repositoryJournalPdo.GetAll().Select(x => x.Id).ToList();

            foreach (var journalIdItem in journalsId)
            {

                JournalPdo journalPdo = _repositoryJournalPdo.GetAll().Where(x => x.Id == journalIdItem).FirstOrDefault();
                int journalPdoId = _repositoryJournalPdo.GetAll().Where(x => x.Id == journalIdItem).Select(x => x.Id).FirstOrDefault();

                var pdoModels = _repositoryPdo.GetAll().Where(x => x.JournalPdoId == journalPdoId).ToList();
                var notWithdrawalFromRegistrationModels = GetNotWithdrawalFromRegistration(pdoModels, journalPdoId);
                var oldPdoModel = GetOldPdoModel(pdoModels, journalPdoId);

                var pdoDtoModel = new ReportPdoDto();
                pdoDtoModel.Quantity = notWithdrawalFromRegistrationModels.Count();
                pdoDtoModel.QuantityOld = oldPdoModel.Count();
                pdoDtoModel.NameJournal = journalPdo.Name;
                pdoDtoModel.PercentOld = GetPercentOld(notWithdrawalFromRegistrationModels.Count(), oldPdoModel.Count());
                pdoDtoModel.QuantityAll = pdoDtoModel.Quantity;
                pdoDtoModel.QuantityAllOld = pdoDtoModel.QuantityOld;
                pdoDtoModel.PercentAllOld = GetPercentOld(reportPdoDto.Select(x => x.QuantityAll).Sum(), reportPdoDto.Select(x => x.QuantityAllOld).Sum());
                

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
                    pdoDtoModelByTypes.PercentOld = GetPercentOld(modelsByType.Count(), modelsOldByType.Count());
                    reportPdoDto.Add(pdoDtoModelByTypes);
                }
            }
            return reportPdoDto;
        }
    }
}
