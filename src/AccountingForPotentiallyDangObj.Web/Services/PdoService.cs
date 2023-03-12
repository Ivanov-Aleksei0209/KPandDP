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

                modelDto.JournalPdoId = journalPdoById.JournalNumber;
                modelDto.TypeName = typeOfPdoById.Abb;
                modelDto.TechnicalConditionalName = techCondModelById.Name;
                modelDto.InspectorName = inspectorById.Name;
                modelDto.SubjectName = subjectById.Name;
            }
            return modelsDto;
        }

        public IEnumerable<ReportPdoDto> GetReportPdo()
        {
            var pdoModels = _repositoryPdo.GetAll().ToList();
            var typesPdoModels = _repositoryTypeOfPdo.GetAll().ToList();
            var journalsPdoModels = _repositoryJournalPdo.GetAll().ToList();

            var typesPdoId = new List<int>();
            typesPdoId = _repositoryTypeOfPdo.GetAll().Select(x => x.Id).ToList();

            var journalsPdoId = new List<int>();
            journalsPdoId = _repositoryJournalPdo.GetAll().Select(x => x.Id).ToList();


            var reportsPdoDto = new List<ReportPdoDto>();

            for (var j = 0; j < journalsPdoId.Count(); j++)
            {
                var journalPdoId = journalsPdoId[j];


                var tempCollectionModels = new List<Pdo>();
                var tempCollectionOldModels = new List<Pdo>();
                var reportPdoModel = new ReportPdoDto();

                for (var i = 0; i < pdoModels.Count(); i++)
                {
                    var pdoModel = pdoModels[i];
                    if (pdoModel.JournalPdoId == journalPdoId && pdoModel.WithdrawalFromRegistration == null)
                        tempCollectionModels.Add(pdoModel);
                    if (pdoModel.JournalPdoId == journalPdoId && DateTime.Now.Year - pdoModel.YearOfManufacture > pdoModel.ServiceLife && pdoModel.WithdrawalFromRegistration == null)
                        tempCollectionOldModels.Add(pdoModel);
                }


                reportPdoModel.QuantityJournalPdo = tempCollectionModels.Count();
                reportPdoModel.QuantityJournalPdoOld = tempCollectionOldModels.Count();

                if (tempCollectionModels.Count() != 0)
                {
                    double percentJournalPdoOld = (double)tempCollectionOldModels.Count() / (double)tempCollectionModels.Count() * 100;
                    reportPdoModel.PercentJournalPdoOld = Math.Round(percentJournalPdoOld, 1);
                }
                else { reportPdoModel.PercentJournalPdoOld = 0; }

                var journalPdoModel = journalsPdoModels[j];
                reportPdoModel.NameJournal = journalPdoModel.Name;
                reportPdoModel.JournalNumber = journalPdoModel.JournalNumber;

                reportsPdoDto.Add(reportPdoModel);
                reportPdoModel.QuantityJournalPdo = reportsPdoDto.Sum(x => x.Quantity);

            }

            for (var k = 0; k < typesPdoId.Count(); k++)
            {
                var typePdoId = typesPdoId[k];
                var tempCollectionModels = new List<Pdo>();
                var tempCollectionOldModels = new List<Pdo>();
                var reportPdoModel = new ReportPdoDto();

                for (var i = 0; i < pdoModels.Count(); i++)
                {
                    var pdoModel = pdoModels[i];
                    if (pdoModel.TypeId == typePdoId && pdoModel.WithdrawalFromRegistration == null)
                        tempCollectionModels.Add(pdoModel);
                    if (pdoModel.TypeId == typePdoId && DateTime.Now.Year - pdoModel.YearOfManufacture > pdoModel.ServiceLife && pdoModel.WithdrawalFromRegistration == null)
                        tempCollectionOldModels.Add(pdoModel);
                }

                //if (tempCollectionModels.Count() != 0)
                //{
                reportPdoModel.Quantity = tempCollectionModels.Count();
                reportPdoModel.QuantityOld = tempCollectionOldModels.Count();
                if (tempCollectionModels.Count() != 0)
                {
                    double percentOld = (double)tempCollectionOldModels.Count() / (double)tempCollectionModels.Count() * 100;
                    reportPdoModel.PercentOld = Math.Round(percentOld, 1);
                }
                else { reportPdoModel.PercentOld = 0; }

                reportsPdoDto.Add(reportPdoModel);
                //}
                var typePdoModel = typesPdoModels[k];
                reportPdoModel.TypePdoName = typePdoModel.Name;

                reportPdoModel.SumQuantityJournalPdo = reportsPdoDto.Sum(x => x.Quantity);
            }
            return reportsPdoDto;
        }
    }
}
