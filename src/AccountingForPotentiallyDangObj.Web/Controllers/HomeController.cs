using AccountingForPotentiallyDangObj.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.Interfaces;

namespace AccountingForPotentiallyDangObj.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //public readonly IRepository<Inspector> _repositoryInspector;
        private readonly IInspectorService _inspectorService;
        private readonly IMapperConfig _mapperConfig;
        public HomeController(IInspectorService inspectorService, IMapperConfig mapperConfig)
        {
            _inspectorService = inspectorService;
            _mapperConfig = mapperConfig;
        }

        public IActionResult Index()
        {
            var inspectorsDto = _inspectorService.GetAllAsync();
            var modelsView = _mapperConfig.Mapper.Map<IEnumerable<InspectorViewModel>>(inspectorsDto);

            return View(modelsView);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}