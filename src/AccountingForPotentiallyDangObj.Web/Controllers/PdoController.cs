using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AccountingForPotentiallyDangObj.Web.Infrastructure;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;
using AccountingForPotentiallyDangObj.Web.Services;

namespace AccountingForPotentiallyDangObj.Web.Controllers
{
    public class PdoController : Controller
    {
        private readonly IPdoService _pdoService;
        private readonly ITechnicalSpecificationService _technicalSpecificationService;
        private readonly IRepository<JournalPdo> _repositoryJournalPdo;
        private readonly IRepository<TypeOfPdo> _repositoryTypeOfPdo;
        private readonly IRepository<TechnicalConditional> _repositoryTechnicalConditional;
        private readonly IRepository<Inspector> _repositoryInspector;
        private readonly IRepository<Subject> _repositorySubject;
        private readonly IRepository<InstallationLocation> _repositoryInstallationLocation;
        private readonly IMapperConfig _mapperConfig;
        public PdoController(IPdoService pdoService, ITechnicalSpecificationService technicalSpecificationService, 
            IRepository<JournalPdo> repositoryJournalPdo, IRepository<TypeOfPdo> repositoryTypeOfPdo, IRepository<TechnicalConditional> repositoryTechnicalConditional,
            IRepository<Inspector> repositoryInspector, IRepository<Subject> repositorySubject, IRepository<InstallationLocation> repositoryInstallationLocation, IMapperConfig mapperConfig)
        {
            _pdoService = pdoService;
            _technicalSpecificationService = technicalSpecificationService;
            _repositoryJournalPdo = repositoryJournalPdo;
            _repositoryTypeOfPdo = repositoryTypeOfPdo;
            _repositoryTechnicalConditional = repositoryTechnicalConditional;
            _repositoryInspector = repositoryInspector;
            _repositorySubject = repositorySubject;
            _repositoryInstallationLocation = repositoryInstallationLocation;
            _mapperConfig = mapperConfig;
        }
        public IActionResult Pdo()
        {
            var pdoDto = _pdoService.GetAllPdoAsync();
            var modelsView = _mapperConfig.Mapper.Map<IEnumerable<PdoViewModel>>(pdoDto);
            return View(modelsView);
        }

        public IActionResult ReportPdo()
        {
            var resultModelDto = _pdoService.GetReportPdo();
            var resultModel = _mapperConfig.Mapper.Map<IEnumerable<ReportPdoViewModel>>(resultModelDto);
            return View(resultModel);
        }
        [HttpGet]
        public IActionResult AddNewPdo()
        {
            var modelsJournalPdo = _repositoryJournalPdo.GetAll().ToList();
            SelectList journalNumber = new SelectList(modelsJournalPdo, "JournalNumber", "JournalNumber");
            ViewBag.JournalNumber = journalNumber;
            var modelsTypePdo = _repositoryTypeOfPdo.GetAll().ToList();
            SelectList abb = new SelectList(modelsTypePdo, "Abb", "Abb");
            ViewBag.Abb = abb;
            var modelsInspector = _repositoryInspector.GetAll().ToList().SkipLast(1);
            SelectList inspectorName = new SelectList(modelsInspector, "Name", "Name");
            ViewBag.InspectorName = inspectorName;
            var modelsSubject = _repositorySubject.GetAll().ToList();
            SelectList subjectName = new SelectList(modelsSubject, "Name", "Name");
            ViewBag.SubjectName = subjectName;
            var modelsTechnicalConditional = _repositoryTechnicalConditional.GetAll().ToList();
            SelectList technicalConditionalName = new SelectList(modelsTechnicalConditional, "Name", "Name");
            ViewBag.TechnicalConditionalName = technicalConditionalName;
            var modelsInstallationLocation = _repositoryInstallationLocation.GetAll().ToList();
            SelectList installationLocationName = new SelectList(modelsInstallationLocation, "Name", "Name");
            ViewBag.InstallationLocationName = installationLocationName;
            return View();
        }
        //[HttpPost]
        //public string GetFormJournalPdo(string journalNumberString)
        //{
        //    return journalNumberString;
        //}
        //[HttpPost]
        //public string GetFormTypePdo(string abb)
        //{
        //    return abb;
        //}
        //[HttpPost]
        //public string GetFormInspector(string inspector)
        //{
        //    return inspector;
        //}
        //[HttpPost]
        //public string GetFormSubject(string subject)
        //{
        //    return subject;
        //}
        //[HttpPost]
        //public string GetFormTechnicalConditional(string technicalConditional)
        //{
        //    return technicalConditional;
        //}
        //[HttpPost]
        //public string GetFormInstallationLocation(string installationLocation)
        //{
        //    return installationLocation;
        //}

        [HttpPost]
        public async Task<IActionResult> AddNewPdo(PdoViewModel model)
        {

            var resultModel = _mapperConfig.Mapper.Map<PdoDto>(model);
            //resultModel.JournalNumber = Convert.ToInt32(model.JournalNumberString);
            resultModel.DateOfRegistration = DateTime.Parse(model.DateOfRegistrationString);

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
            } else { technicalSpecificationModelDto.Capacity = null; }

            if (model.SpeedString != null)
            {
                technicalSpecificationModelDto.Speed = double.Parse(model.SpeedString);
            }else { technicalSpecificationModelDto.Speed = null; }

            


            //var technicalSpecificationService = new TechnicalSpecificationService();
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


            var resultViewModel = await _pdoService.AddNewPdoAsync(resultModel);
            return Redirect("Pdo");
        }

        //[HttpGet]
        public async Task<IActionResult> EditPdo(int id)
        {
            var resultModelDto = await _pdoService.EditPdoAsync(id);
            var resultModel = _mapperConfig.Mapper.Map<IEnumerable<PdoViewModel>>(resultModelDto);
            return View();
        }
    }
}
