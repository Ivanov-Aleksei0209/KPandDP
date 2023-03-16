using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;

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

        public IEnumerable<PdoDto> GetAllAsync()
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
            //var pdoModels = _repositoryPdo.GetAll().ToList();
            //var typesPdoModels = _repositoryTypeOfPdo.GetAll().ToList();
            //var journalsPdoModels = _repositoryJournalPdo.GetAll().ToList();

            //var typesPdoId = new List<int>();
            //typesPdoId = _repositoryTypeOfPdo.GetAll().Select(x => x.Id).ToList();

            //var journalsPdoId = new List<int>();
            //journalsPdoId = _repositoryJournalPdo.GetAll().Select(x => x.Id).ToList();


            //var reportsPdoDto = new List<ReportPdoDto>();

            //for (var j = 0; j < journalsPdoId.Count(); j++)
            //{
            //    var journalPdoId = journalsPdoId[j];


            //    var tempCollectionModels = new List<Pdo>();
            //    var tempCollectionOldModels = new List<Pdo>();
            //    var reportPdoModel = new ReportPdoDto();

            //    for (var i = 0; i < pdoModels.Count(); i++)
            //    {
            //        var pdoModel = pdoModels[i];
            //        if (pdoModel.JournalPdoId == journalPdoId && pdoModel.WithdrawalFromRegistration == null)
            //            tempCollectionModels.Add(pdoModel);
            //        if (pdoModel.JournalPdoId == journalPdoId && DateTime.Now.Year - pdoModel.YearOfManufacture > pdoModel.ServiceLife && pdoModel.WithdrawalFromRegistration == null)
            //            tempCollectionOldModels.Add(pdoModel);
            //    }

            //    reportPdoModel.QuantityJournalPdo = tempCollectionModels.Count();
            //    reportPdoModel.QuantityJournalPdoOld = tempCollectionOldModels.Count();

            //    if (tempCollectionModels.Count() != 0)
            //    {
            //        double percentJournalPdoOld = (double)tempCollectionOldModels.Count() / (double)tempCollectionModels.Count() * 100;
            //        reportPdoModel.PercentJournalPdoOld = Math.Round(percentJournalPdoOld, 1);
            //    }
            //    else { reportPdoModel.PercentJournalPdoOld = 0; }

            //    var journalPdoModel = journalsPdoModels[j];
            //    reportPdoModel.NameJournal = journalPdoModel.Name;
            //    reportPdoModel.JournalNumber = journalPdoModel.JournalNumber;

            //    reportsPdoDto.Add(reportPdoModel);

            //}

            //for (var k = 0; k < typesPdoId.Count(); k++)
            //{
            //    var typePdoId = typesPdoId[k];
            //    var tempCollectionModels = new List<Pdo>();
            //    var tempCollectionOldModels = new List<Pdo>();
            //    var reportPdoModel = new ReportPdoDto();

            //    for (var i = 0; i < pdoModels.Count(); i++)
            //    {
            //        var pdoModel = pdoModels[i];
            //        if (pdoModel.TypeId == typePdoId && pdoModel.WithdrawalFromRegistration == null)

            //            tempCollectionModels.Add(pdoModel);

            //        if (pdoModel.TypeId == typePdoId && DateTime.Now.Year - pdoModel.YearOfManufacture > pdoModel.ServiceLife && pdoModel.WithdrawalFromRegistration == null)

            //        tempCollectionOldModels.Add(pdoModel);

            //    }

            //    reportPdoModel.Quantity = tempCollectionModels.Count();
            //    reportPdoModel.QuantityOld = tempCollectionOldModels.Count();
            //    if (tempCollectionModels.Count() != 0)
            //    {
            //        double percentOld = (double)tempCollectionOldModels.Count() / (double)tempCollectionModels.Count() * 100;
            //        reportPdoModel.PercentOld = Math.Round(percentOld, 1);
            //    }
            //    else { reportPdoModel.PercentOld = 0; }

            //    reportsPdoDto.Add(reportPdoModel);
            //    //}
            //    var typePdoModel = typesPdoModels[k];
            //    reportPdoModel.TypePdoName = typePdoModel.Name;

            //    //reportPdoModel.SumQuantityJournalPdo = reportsPdoDto.Sum(x => x.Quantity);
            //}

            var reportPdoDto = new List<ReportPdoDto>();

            JournalPdo journalPdoCrane = _repositoryJournalPdo.GetAll().Where(x => x.Name == "Грузоподъемные краны").FirstOrDefault();
            int journalPdoIdCrane = _repositoryJournalPdo.GetAll().Where(x => x.Name == "Грузоподъемные краны").Select(x => x.Id).FirstOrDefault();

            var pdoModelsCranes = _repositoryPdo.GetAll().Where(x => x.JournalPdoId == journalPdoIdCrane).ToList();

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

            var notWithdrawalFromRegistrationModels = GetNotWithdrawalFromRegistration(pdoModelsCranes, journalPdoIdCrane);
            var oldPdoModelCranes = GetOldPdoModel(pdoModelsCranes, journalPdoIdCrane);

            var pdoDtoModelCranes = new ReportPdoDto();
            pdoDtoModelCranes.Quantity = notWithdrawalFromRegistrationModels.Count();
            pdoDtoModelCranes.QuantityOld = oldPdoModelCranes.Count();
            pdoDtoModelCranes.NameJournal = journalPdoCrane.Name;
            pdoDtoModelCranes.PercentOld = GetPercentOld(notWithdrawalFromRegistrationModels.Count(), oldPdoModelCranes.Count());
            
            reportPdoDto.Add(pdoDtoModelCranes);

            List<int> typesId = new List<int>();
            typesId = notWithdrawalFromRegistrationModels.Select(x => x.TypeId).Distinct().ToList();

            //var pdoDtoModelByTypesCrane = new ReportPdoDto();

            foreach (var typeIdItem in typesId)
            {
                var pdoDtoModelByTypesCrane = new ReportPdoDto();
                var modelsByTypeCrane = notWithdrawalFromRegistrationModels.Where(x => x.TypeId == typeIdItem).ToList();
                var modelsOldByTypeCrane = oldPdoModelCranes.Where(x => x.TypeId == typeIdItem).ToList();
                pdoDtoModelByTypesCrane.NameJournal = _repositoryTypeOfPdo.GetAll().Where(x => x.Id == typeIdItem).Select(x => x.Name).FirstOrDefault();
                pdoDtoModelByTypesCrane.Quantity = modelsByTypeCrane.Count();
                pdoDtoModelByTypesCrane.QuantityOld = modelsOldByTypeCrane.Count();
                pdoDtoModelByTypesCrane.PercentOld = GetPercentOld(modelsByTypeCrane.Count(), modelsOldByTypeCrane.Count());
                reportPdoDto.Add(pdoDtoModelByTypesCrane);
            }

            return reportPdoDto;
        }
    }
}
