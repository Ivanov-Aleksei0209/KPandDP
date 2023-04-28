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
        private readonly IPdoHelper _pdoHelper;
        private readonly ITechnicalSpecificationService _technicalSpecificationService;
        private readonly IRepository<JournalPdo> _repositoryJournalPdo;
        private readonly IRepository<TypeOfPdo> _repositoryTypeOfPdo;
        private readonly IRepository<TechnicalConditional> _repositoryTechnicalConditional;
        private readonly IRepository<Inspector> _repositoryInspector;
        private readonly IRepository<Subject> _repositorySubject;
        private readonly IRepository<InstallationLocation> _repositoryInstallationLocation;
        private readonly IMapperConfig _mapperConfig;
        public PdoController(IPdoService pdoService, IPdoHelper pdoHelper, ITechnicalSpecificationService technicalSpecificationService, 
            IRepository<JournalPdo> repositoryJournalPdo, IRepository<TypeOfPdo> repositoryTypeOfPdo, 
            IRepository<TechnicalConditional> repositoryTechnicalConditional,
            IRepository<Inspector> repositoryInspector, IRepository<Subject> repositorySubject, 
            IRepository<InstallationLocation> repositoryInstallationLocation, IMapperConfig mapperConfig)
        {
            _pdoService = pdoService;
            _pdoHelper = pdoHelper;
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
        public IActionResult CreatePdo()
        {
            var modelsJournalPdo = _repositoryJournalPdo.GetAll().ToList();
            SelectList journalNumber = new SelectList(modelsJournalPdo, "JournalNumber", "JournalNumber");
            ViewBag.JournalNumber = journalNumber;
            var modelsTypePdo = _repositoryTypeOfPdo.GetAll().ToList();
            SelectList abb = new SelectList(modelsTypePdo, "Abb", "Abb");
            ViewBag.Abb = abb;
            var modelsInspector = _repositoryInspector.GetAll().ToList();
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

        [HttpPost]
        public async Task<IActionResult> CreatePdo(PdoViewModel model)
        {

            var resultModel = await _pdoHelper.GetPdoDtoForAddAsync(model);

            var resultViewModel = await _pdoService.CreatePdoAsync(resultModel);
            return RedirectToAction(nameof(Pdo));
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePdo(int id)
        {
            var resultModelDto = await _pdoHelper.GetPdoDtoByIdAsync(id);

            var modelsJournalPdo = _repositoryJournalPdo.GetAll().ToList();
            SelectList journalNumber = new SelectList(modelsJournalPdo, "JournalNumber", "JournalNumber", resultModelDto.JournalNumber);
            ViewBag.JournalNumber = journalNumber;

            var modelsTypePdo = _repositoryTypeOfPdo.GetAll().ToList();
            SelectList abb = new SelectList(modelsTypePdo, "Abb", "Abb", resultModelDto.TypeName);
            ViewBag.Abb = abb;

            var modelsInspector = _repositoryInspector.GetAll().ToList().SkipLast(1);
            SelectList inspectorName = new SelectList(modelsInspector, "Name", "Name", resultModelDto.InspectorName);
            ViewBag.InspectorName = inspectorName;

            var modelsSubject = _repositorySubject.GetAll().ToList();
            SelectList subjectName = new SelectList(modelsSubject, "Name", "Name", resultModelDto.SubjectName);
            ViewBag.SubjectName = subjectName;

            var modelsTechnicalConditional = _repositoryTechnicalConditional.GetAll().ToList();
            SelectList technicalConditionalName = new SelectList(modelsTechnicalConditional, "Name", "Name", resultModelDto.TechnicalConditionalName);
            ViewBag.TechnicalConditionalName = technicalConditionalName;

            var modelsInstallationLocation = _repositoryInstallationLocation.GetAll().ToList();
            SelectList installationLocationName = new SelectList(modelsInstallationLocation, "Name", "Name", resultModelDto.InstallationLocationName);
            ViewBag.InstallationLocationName = installationLocationName;

            var resultModel = _mapperConfig.Mapper.Map<PdoViewModel>(resultModelDto);
            return View(resultModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePdo(PdoViewModel model)
        {
            var resultModel = await _pdoHelper.GetPdoDtoForUpdateAsync(model);

            var resultViewModel = await _pdoService.UpdatePdoAsync(resultModel);
            return RedirectToAction(nameof(Pdo));
        }
    }
}
