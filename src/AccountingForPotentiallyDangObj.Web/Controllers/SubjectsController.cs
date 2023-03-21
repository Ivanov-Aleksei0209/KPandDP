using AccountingForPotentiallyDangObj.Web.Interfaces;
using AccountingForPotentiallyDangObj.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountingForPotentiallyDangObj.Web.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapperConfig _mapperConfig;

        public SubjectsController(ISubjectService subjectService, IMapperConfig mapperConfig)
        {
            _subjectService = subjectService;
            _mapperConfig = mapperConfig;
        }

        public ActionResult Subject()
        {
            var subjectDto = _subjectService.GetAllSubjectAsync();
            var modelsView = _mapperConfig.Mapper.Map<IEnumerable<SubjectViewModel>>(subjectDto);
            return View(modelsView);
        }


    }
}
