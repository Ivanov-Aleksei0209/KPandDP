using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AccountingForPotentiallyDangObj.Web.Infrastructure;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;

namespace AccountingForPotentiallyDangObj.Web.Controllers
{
    public class PdoController : Controller
    {
        private readonly IPdoService _pdoService;
        private readonly IRepository<JournalPdo> _repositoryJournalPdo;
        private readonly IRepository<TypeOfPdo> _repositoryTypeOfPdo;
        private readonly IRepository<TechnicalConditional> _repositoryTechnicalConditional;
        private readonly IRepository<Inspector> _repositoryInspector;
        private readonly IRepository<Subject> _repositorySubject;
        private readonly IRepository<InstallationLocation> _repositoryInstallationLocation;
        private readonly IMapperConfig _mapperConfig;
        public PdoController(IPdoService pdoService, IRepository<JournalPdo> repositoryJournalPdo, IRepository<TypeOfPdo> repositoryTypeOfPdo, IRepository<TechnicalConditional> repositoryTechnicalConditional,
            IRepository<Inspector> repositoryInspector, IRepository<Subject> repositorySubject, IRepository<InstallationLocation> repositoryInstallationLocation, IMapperConfig mapperConfig)
        {
            _pdoService = pdoService;
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
            SelectList journalNumberString = new SelectList(modelsJournalPdo, "Name", "Name");
            ViewBag.JournalNumberString = journalNumberString;
            var modelsTypePdo = _repositoryTypeOfPdo.GetAll().ToList();
            SelectList abb = new SelectList(modelsTypePdo, "Abb", "Abb");
            ViewBag.Abb = abb;
            var modelsInspector = _repositoryInspector.GetAll().ToList().SkipLast(1);
            SelectList inspector = new SelectList(modelsInspector, "Name", "Name");
            ViewBag.NameInspector = inspector;
            var modelsSubject = _repositorySubject.GetAll().ToList();
            SelectList subject = new SelectList(modelsSubject, "Name", "Name");
            ViewBag.NameSubject = subject;
            var modelsTechnicalConditional = _repositoryTechnicalConditional.GetAll().ToList();
            SelectList technicalConditional = new SelectList(modelsTechnicalConditional, "Name", "Name");
            ViewBag.NameTechnicalConditional = technicalConditional;
            var modelsInstallationLocation = _repositoryInstallationLocation.GetAll().ToList();
            SelectList installationLocation = new SelectList(modelsInstallationLocation, "Name", "Name");
            ViewBag.NameInstallationLocation = installationLocation;
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
            resultModel.JournalNumber = Convert.ToInt32(model.JournalNumberString);
            resultModel.DateOfRegistration = DateTime.Parse(model.DateOfRegistrationString);



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
