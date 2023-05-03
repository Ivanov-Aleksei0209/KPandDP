using AccountingForPotentiallyDangObj.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using AccountingForPotentiallyDangObj.Web.Helpers;

namespace AccountingForPotentiallyDangObj.Web.Controllers
{
    public class InspectorsController : Controller
    {
        private readonly IInspectorService _inspectorService;
        private readonly IInspectorHelper _inspectorHelper;
        private readonly IRepository<Role> _repositoryRole;
        private readonly IMapperConfig _mapperConfig;
        public InspectorsController(IInspectorService inspectorService, IInspectorHelper inspectorHelper, IRepository<Role> repositoryRole, IMapperConfig mapperConfig)
        {
            _inspectorService = inspectorService;
            _inspectorHelper = inspectorHelper;
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
        public ActionResult CreateInspector()
        {
            var modelsRole = _repositoryRole.GetAll().ToList();
            SelectList roleName = new SelectList(modelsRole, "Name", "Name");
            ViewBag.RoleName = roleName;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateInspector(InspectorViewModel model)
        {
            var resultModel = await _inspectorHelper.GetInspectorDtoForCreate(model);

            var resultViewModel = await _inspectorService.CreateInspectorAsync(resultModel);

            return RedirectToAction(nameof(Inspectors));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateInspector(int id)
        {
            var resultModelDto = await _inspectorHelper.GetInspectorDtoByIdAsync(id);

            var modelsRole = _repositoryRole.GetAll().ToList();
            SelectList roleName = new SelectList(modelsRole, "Name", "Name", resultModelDto.RoleName);
            ViewBag.RoleName = roleName;

            var resultModel = _mapperConfig.Mapper.Map<InspectorViewModel>(resultModelDto);

            return View(resultModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInspector(InspectorViewModel model)
        {
            var resultModel = await _inspectorHelper.GetInspectorDtoForUpdateAsync(model);

            var resultViewModel = await _inspectorService.UpdateInspectorAsync(resultModel);
            
            return RedirectToAction(nameof(Inspectors));
        }
    }
}
