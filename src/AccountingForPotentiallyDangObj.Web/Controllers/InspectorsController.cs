using AccountingForPotentiallyDangObj.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AccountingForPotentiallyDangObj.Web.Controllers
{
    public class InspectorsController : Controller
    {
        private readonly IInspectorService _inspectorService;
        private readonly IRepository<Role> _repositoryRole;
        private readonly IMapperConfig _mapperConfig;
        public InspectorsController(IInspectorService inspectorService, IRepository<Role> repositoryRole, IMapperConfig mapperConfig)
        {
            _inspectorService = inspectorService;
            _repositoryRole = repositoryRole;
            _mapperConfig = mapperConfig;
        }
       
        public IActionResult Inspectors()
        {
            var inspectorsDto = _inspectorService.GetAllInspectorAsync();
            var modelsView = _mapperConfig.Mapper.Map<IEnumerable<InspectorViewModel>>(inspectorsDto);
            return View(modelsView);
        }
        [HttpGet]
        public ActionResult AddNewInspector()
        {
            var modelsRole = _repositoryRole.GetAll().ToList();
            SelectList roleName = new SelectList(modelsRole, "Name", "Name");
            ViewBag.RoleName = roleName;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewInspector(InspectorViewModel model)
        {
            var resultModel = await _inspectorService.MapInspectorViewModelToInspectorDto(model);
            var resultViewModel = await _inspectorService.AddNewInspectorAsync(resultModel);
            return Redirect("Inspectors");
        }
    }
}
