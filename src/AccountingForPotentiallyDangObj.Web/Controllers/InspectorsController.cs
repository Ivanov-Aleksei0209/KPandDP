using AccountingForPotentiallyDangObj.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.Interfaces;

namespace AccountingForPotentiallyDangObj.Web.Controllers
{
    public class InspectorsController : Controller
    {
        private readonly IInspectorService _inspectorService;
        private readonly IMapperConfig _mapperConfig;
        public InspectorsController(IInspectorService inspectorService, IMapperConfig mapperConfig)
        {
            _inspectorService = inspectorService;
            _mapperConfig = mapperConfig;
        }
       
        public IActionResult Inspectors()
        {
            var inspectorsDto = _inspectorService.GetAllInspectorAsync();
            var modelsView = _mapperConfig.Mapper.Map<IEnumerable<InspectorViewModel>>(inspectorsDto);
            return View(modelsView);
        }
    }
}
