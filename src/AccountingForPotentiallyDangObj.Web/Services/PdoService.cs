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

        public PdoService(IRepository<Pdo> repositoryPdo, IRepository<JournalPdo> repositoryJournalPdo, IRepository<TypeOfPdo> repositoryTypeOfPdo,IRepository<TechnicalConditional> repositoryTechnicalConditional, 
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

                //modelDto.JournalPdoId = journalPdoById.JournalNumber;
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
            
            var typesPdoId = new List<int>();
            typesPdoId = _repositoryTypeOfPdo.GetAll().Select(x => x.Id).ToList();

            //var tempCollectionModels = new List<Pdo>();

            var reportsPdoDto = new List<ReportPdoDto>();

            for (var k = 0; k < typesPdoId.Count(); k++)
            {
                var typePdoId = typesPdoId[k];
                var tempCollectionModels = new List<Pdo>();

                for (var i = 0; i < pdoModels.Count(); i++)
                {
                    var pdoModel = pdoModels[i];
                    if (pdoModel.TypeId == typePdoId && pdoModel.WithdrawalFromRegistration == null)
                    tempCollectionModels.Add(pdoModel);
                }
                var reportPdoModel = new ReportPdoDto();
                
                if (tempCollectionModels.Count() != null)
                {
                    reportPdoModel.Quantity = tempCollectionModels.Count();
                    reportsPdoDto.Add(reportPdoModel);
                }
                var typePdoModel = typesPdoModels[k];
                reportPdoModel.TypePdoName = typePdoModel.Name;

                //reportPdoModel.TypePdoName = typesPdoModels.Where(x => x.Id == typePdoId).Select(x => x.Name);
                //reportsPdoDto.Add(reportPdoModel);
            }            
            return reportsPdoDto;
        }


        

    }
}
