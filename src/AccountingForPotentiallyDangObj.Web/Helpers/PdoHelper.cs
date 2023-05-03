using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using AccountingForPotentiallyDangObj.Web.Models;

namespace AccountingForPotentiallyDangObj.Web.Helpers
{
    public class PdoHelper : IPdoHelper
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

        public PdoHelper(IRepository<Pdo> repositoryPdo, ITechnicalSpecificationService technicalSpecificationService, IRepository<JournalPdo> repositoryJournalPdo, IRepository<TypeOfPdo> repositoryTypeOfPdo, IRepository<TechnicalConditional> repositoryTechnicalConditional,
            IRepository<Inspector> repositoryInspector, IRepository<Subject> repositorySubject, IRepository<InstallationLocation> repositoryInstallationLocation,
            IRepository<TechnicalSpecification> repositoryTechnicalSpecification, IMapperConfig mapperConfig)
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
        }
        //public PdoHelper() { }
        
        // метод подсчета ПОО не снятых с учета
        public List<Pdo> GetNotWithdrawalFromRegistration(List<Pdo> models, int journalPdoId)
        {
            var tempCollectionModels = new List<Pdo>();
            for (var i = 0; i < models.Count(); i++)
            {
                var pdoModel = models[i];
                if (pdoModel.JournalPdoId == journalPdoId && pdoModel.WithdrawalFromRegistration == null || pdoModel.WithdrawalFromRegistration.ToString() == "01.01.0001 0:00:00")
                    tempCollectionModels.Add(pdoModel);

            }
            return tempCollectionModels;
        }

        // метод подсчета ПОО, отработавших назначенный срок службы
        public List<Pdo> GetOldPdoModel(List<Pdo> models, int journalPdoId)
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
        public double GetPercentOld(int notWithdrawalFromRegistration, int oldPdo)
        {
            double percentOld;
            if (notWithdrawalFromRegistration != 0)
            {
                percentOld = Math.Round((double)oldPdo / (double)notWithdrawalFromRegistration * 100, 1);
            }
            else { percentOld = 0; }

            return percentOld;
        }


        public async Task<PdoDto> GetPdoDtoForAddAsync(PdoViewModel model)
        {
            var resultModel = _mapperConfig.Mapper.Map<PdoDto>(model);

            if (!String.IsNullOrEmpty(model.DateOfRegistrationStringViewModel))
            {
                resultModel.DateOfRegistration = DateTime.Parse(model.DateOfRegistrationStringViewModel);
            }

            if (model.InformationAboutTheLastSurveyString.Length > 0)
            {
                resultModel.InformationAboutTheLastSurvey = DateTime.Parse(model.InformationAboutTheLastSurveyString);
            }
            if (model.InformationAboutTheTechnicalDiagnosticString.Length > 0)
            {
                resultModel.InformationAboutTheTechnicalDiagnostic = DateTime.Parse(model.InformationAboutTheTechnicalDiagnosticString);
            }
            if (model.InformationAboutTheTechnicalInspectionString.Length > 0)
            {
                resultModel.InformationAboutTheTechnicalInspection = DateTime.Parse(model.InformationAboutTheTechnicalInspectionString);
            }

            var technicalSpecificationModelDto = new TechnicalSpecificationDto();

            technicalSpecificationModelDto.NumberOfStops = model.NumberOfStops;
            if (model.ArrowDepartureString != null)
            {
                technicalSpecificationModelDto.ArrowDeparture = double.Parse(model.ArrowDepartureString);
            }
            else
            {
                technicalSpecificationModelDto.ArrowDeparture = null;
            }

            if (model.CapacityString != null)
            {
                technicalSpecificationModelDto.Capacity = double.Parse(model.CapacityString);
            }
            else { technicalSpecificationModelDto.Capacity = null; }

            if (model.SpeedString != null)
            {
                technicalSpecificationModelDto.Speed = double.Parse(model.SpeedString);
            }
            else { technicalSpecificationModelDto.Speed = null; }

            var technicalSpecificationFromDb = await _technicalSpecificationService.AddTechnicalSpecificationAsync(technicalSpecificationModelDto);
            resultModel.TechnicalSpecificationId = technicalSpecificationFromDb.Id;

            var modelsJournalPdo = _repositoryJournalPdo.GetAll();
            var journalPdoById = modelsJournalPdo.Where(x => x.JournalNumber == model.JournalNumber).FirstOrDefault();
            resultModel.JournalPdoId = journalPdoById.Id;

            var modelsTypeOfPdo = _repositoryTypeOfPdo.GetAll();
            var typeOfPdoById = modelsTypeOfPdo.Where(x => x.Abb == model.Abb).FirstOrDefault();
            resultModel.TypeId = typeOfPdoById.Id;

            var modelsTechnicalConditional = _repositoryTechnicalConditional.GetAll();
            var technicalConditionalById = modelsTechnicalConditional.Where(x => x.Name == model.TechnicalConditionalName).FirstOrDefault();
            resultModel.TechnicalConditionalId = technicalConditionalById.Id;

            var modelsInspector = _repositoryInspector.GetAll();
            var inspectorById = modelsInspector.Where(x => x.Name == model.InspectorName).FirstOrDefault();
            resultModel.InspectorId = inspectorById.Id;

            var modelsSubject = _repositorySubject.GetAll();
            var subjectById = modelsSubject.Where(x => x.Name == model.SubjectName).FirstOrDefault();
            resultModel.SubjectId = subjectById.Id;

            var modelsInstallationLocation = _repositoryInstallationLocation.GetAll();
            var installationLocationById = modelsInstallationLocation.Where(x => x.Name == model.InstallationLocationName).FirstOrDefault();
            resultModel.InstallationLocationId = installationLocationById.Id;


            return resultModel;
        }

        public async Task<PdoDto> GetPdoDtoByIdAsync(int id)
        {
            var modelById = await _repositoryPdo.GetByIdAsync(id);
            var modelsJournalPdo = _repositoryJournalPdo.GetAll();
            var modelsTypeOfPdo = _repositoryTypeOfPdo.GetAll();
            var modelsTechnicalConditional = _repositoryTechnicalConditional.GetAll();
            var modelsInspector = _repositoryInspector.GetAll();
            var modelsSubject = _repositorySubject.GetAll();
            var modelsInstallationLocation = _repositoryInstallationLocation.GetAll();
            var modelsTechnicalSpecification = _repositoryTechnicalSpecification.GetAll();
            var modelDto = _mapperConfig.Mapper.Map<PdoDto>(modelById);

            var journalPdoById = modelsJournalPdo.Where(x => x.Id == modelDto.JournalPdoId).FirstOrDefault();
            var typeOfPdoById = modelsTypeOfPdo.Where(x => x.Id == modelDto.TypeId).FirstOrDefault();
            var techCondModelById = modelsTechnicalConditional.Where(x => x.Id == modelDto.TechnicalConditionalId).FirstOrDefault();
            var inspectorById = modelsInspector.Where(x => x.Id == modelDto.InspectorId).FirstOrDefault();
            var subjectById = modelsSubject.Where(x => x.Id == modelDto.SubjectId).FirstOrDefault();
            var technicalSpecificationById = modelsTechnicalSpecification.Where(x => x.Id == modelDto.TechnicalSpecificationId).FirstOrDefault();
            var installationLocationById = modelsInstallationLocation.Where(x => x.Id == modelDto.InstallationLocationId).FirstOrDefault();

            modelDto.JournalNumber = journalPdoById.JournalNumber;
            modelDto.TypeName = typeOfPdoById.Abb;
            modelDto.TechnicalConditionalName = techCondModelById.Name;
            modelDto.InspectorName = inspectorById.Name;
            modelDto.SubjectName = subjectById.Name;
            modelDto.TechnicalSpecificationId = technicalSpecificationById.Id;
            modelDto.CapacityString = technicalSpecificationById.Capacity.ToString();
            modelDto.ArrowDepartureString = technicalSpecificationById.ArrowDeparture.ToString();
            modelDto.NumberOfStops = technicalSpecificationById.NumberOfStops;
            modelDto.SpeedString = technicalSpecificationById.Speed.ToString();
            if (installationLocationById != null)
            modelDto.InstallationLocationName = installationLocationById.Name;

            return modelDto;

        }
        public async Task<PdoDto> GetPdoDtoForUpdateAsync(PdoViewModel model)
        {

            var resultModel = _mapperConfig.Mapper.Map<PdoDto>(model);

            if (model.DateOfRegistrationString.Length > 0)
            {
                resultModel.DateOfRegistration = DateTime.Parse(model.DateOfRegistrationString);
            }

            if (model.InformationAboutTheLastSurveyString.Length > 0)
            {
                resultModel.InformationAboutTheLastSurvey = DateTime.Parse(model.InformationAboutTheLastSurveyString);
            }
            if (model.InformationAboutTheTechnicalDiagnosticString.Length > 0)
            {
                resultModel.InformationAboutTheTechnicalDiagnostic = DateTime.Parse(model.InformationAboutTheTechnicalDiagnosticString);
            }
            if (model.InformationAboutTheTechnicalInspectionString.Length > 0)
            {
                resultModel.InformationAboutTheTechnicalInspection = DateTime.Parse(model.InformationAboutTheTechnicalInspectionString);
            }
            if (model.WithdrawalFromRegistrationString.Length > 0)
            {
                resultModel.WithdrawalFromRegistration = DateTime.Parse(model.WithdrawalFromRegistrationString);
            }

            var modelById = await _repositoryPdo.GetByIdAsync(model.Id);
            var modelTechnicalSpecificationById = await _repositoryTechnicalSpecification.GetByIdAsync(modelById.TechnicalSpecificationId);
            
            var resultTechnicalSpecificationModelDto = _mapperConfig.Mapper.Map<TechnicalSpecificationDto>(modelTechnicalSpecificationById);

            //var technicalSpecificationModelDto = modelTechnicalSpecificationById.;


            resultTechnicalSpecificationModelDto.NumberOfStops = model.NumberOfStops;
            if (model.ArrowDepartureString != null)
            {
                resultTechnicalSpecificationModelDto.ArrowDeparture = double.Parse(model.ArrowDepartureString);
            }
            else
            {
                resultTechnicalSpecificationModelDto.ArrowDeparture = null;
            }

            if (model.CapacityString != null)
            {
                resultTechnicalSpecificationModelDto.Capacity = double.Parse(model.CapacityString);
            }
            else { resultTechnicalSpecificationModelDto.Capacity = null; }

            if (model.SpeedString != null)
            {
                resultTechnicalSpecificationModelDto.Speed = double.Parse(model.SpeedString);
            }
            else { resultTechnicalSpecificationModelDto.Speed = null; }
            resultTechnicalSpecificationModelDto.Id = (await _repositoryPdo.GetByIdAsync(model.Id)).TechnicalSpecificationId;

            var technicalSpecificationFromDb = await _technicalSpecificationService.UpdateTechnicalSpecificationAsync(resultTechnicalSpecificationModelDto);
            resultModel.TechnicalSpecificationId = technicalSpecificationFromDb.Id;

            var modelsJournalPdo = _repositoryJournalPdo.GetAll();
            var journalPdoById = modelsJournalPdo.Where(x => x.JournalNumber == model.JournalNumber).FirstOrDefault();
            resultModel.JournalPdoId = journalPdoById.Id;

            var modelsTypeOfPdo = _repositoryTypeOfPdo.GetAll();
            var typeOfPdoById = modelsTypeOfPdo.Where(x => x.Abb == model.Abb).FirstOrDefault();
            resultModel.TypeId = typeOfPdoById.Id;

            var modelsTechnicalConditional = _repositoryTechnicalConditional.GetAll();
            var technicalConditionalById = modelsTechnicalConditional.Where(x => x.Name == model.TechnicalConditionalName).FirstOrDefault();
            resultModel.TechnicalConditionalId = technicalConditionalById.Id;

            var modelsInspector = _repositoryInspector.GetAll();
            var inspectorById = modelsInspector.Where(x => x.Name == model.InspectorName).FirstOrDefault();
            resultModel.InspectorId = inspectorById.Id;

            var modelsSubject = _repositorySubject.GetAll();
            var subjectById = modelsSubject.Where(x => x.Name == model.SubjectName).FirstOrDefault();
            resultModel.SubjectId = subjectById.Id;

            var modelsInstallationLocation = _repositoryInstallationLocation.GetAll();
            var installationLocationById = modelsInstallationLocation.Where(x => x.Name == model.InstallationLocationName).FirstOrDefault();
            resultModel.InstallationLocationId = installationLocationById.Id;

            return resultModel;
        }


    }
}
