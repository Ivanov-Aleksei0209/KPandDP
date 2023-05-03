using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using AccountingForPotentiallyDangObj.Web.Models;
using AccountingForPotentiallyDangObj.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.Helpers;
using AccountingForPotentiallyDangObj.Web.Services;

namespace AccountingForPotentiallyDangObj.Web.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly ISubjectHelper _subjectHelper;
        private readonly IRepository<DepartmentalAffiliation> _repositoryDepartmentalAffiliation;
        private readonly IMapperConfig _mapperConfig;

        public SubjectsController(ISubjectService subjectService, ISubjectHelper subjectHelper, IRepository<DepartmentalAffiliation> repositoryDepartmentalAffiliation, IMapperConfig mapperConfig)
        {
            _subjectService = subjectService;
            _subjectHelper = subjectHelper;
            _repositoryDepartmentalAffiliation = repositoryDepartmentalAffiliation;
            _mapperConfig = mapperConfig;
        }

        public ActionResult Subjects()
        {
            var subjectDto = _subjectService.GetAllSubjectAsync();
            var modelsView = _mapperConfig.Mapper.Map<IEnumerable<SubjectViewModel>>(subjectDto);
            return View(modelsView);
        }

        [HttpGet]
        public ActionResult CreateSubject() 
        {
            var modelsDepartmentalAffiliation = _repositoryDepartmentalAffiliation.GetAll().ToList();

            SelectList departmentalAffiliationName = new SelectList(modelsDepartmentalAffiliation, "Name", "Name");

            ViewBag.DepartmentalAffiliationName = departmentalAffiliationName;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubject(SubjectViewModel model)
        {
            var resultModel = await _subjectHelper.GetSubjectDtoForCreate(model);

            var resultViewModel = await _subjectService.CreateSubjectAsync(resultModel);

            return RedirectToAction(nameof(Subjects));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSubject(int id)
        {
            var resultModelDto = await _subjectHelper.GetSubjectDtoByIdAsync(id);

            var modelsDepartmentalAffiliation = _repositoryDepartmentalAffiliation.GetAll().ToList();
            SelectList departmentalAffiliationName = new SelectList(modelsDepartmentalAffiliation, "Name", "Name", resultModelDto.DepartmentalAffiliationName);
            ViewBag.DepartmentalAffiliationName = departmentalAffiliationName;

            var resultModel = _mapperConfig.Mapper.Map<SubjectViewModel>(resultModelDto);

            return View(resultModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubject(SubjectViewModel model)
        {
            var resultModel = await _subjectHelper.GetSubjectDtoForCreate(model);

            var resultViewModel = await _subjectService.UpdateSubjectAsync(resultModel);

            return RedirectToAction(nameof(Subjects));
        }

    }

    
}
