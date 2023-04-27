using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using AccountingForPotentiallyDangObj.Web.Models;
using AccountingForPotentiallyDangObj.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.Web.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly IRepository<DepartmentalAffiliation> _repositoryDepartmentalAffiliation;
        private readonly IMapperConfig _mapperConfig;

        public SubjectsController(ISubjectService subjectService, IRepository<DepartmentalAffiliation> repositoryDepartmentalAffiliation, IMapperConfig mapperConfig)
        {
            _subjectService = subjectService;
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
        public ActionResult AddNewSubject() 
        {
            var modelsDepartmentalAffiliation = _repositoryDepartmentalAffiliation.GetAll().ToList();
            SelectList departmentalAffiliationName = new SelectList(modelsDepartmentalAffiliation, "Name", "Name");
            ViewBag.DepartmentalAffiliationName = departmentalAffiliationName;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSubject(SubjectViewModel model)
        {
            var resultModel = await _subjectService.MapSubjectViewModelToSubjectDto(model);
            var resultViewModel = await _subjectService.AddNewSubjectAsync(resultModel);
            return Redirect("Subjects");
        }

        //public async Task<IActionResult> EditSubjectAsync(int id)
        //{
        //    var resultModelDto = await _subjectService.MapPdoToPdoDto(id);
        //    return View(resultModel);
        //}

    }

    
}
