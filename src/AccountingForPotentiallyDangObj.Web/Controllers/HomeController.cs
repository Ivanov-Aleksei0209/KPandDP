using AccountingForPotentiallyDangObj.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using AccountingForPotentiallyDangObj.Web.Services;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Infrastructure;

namespace AccountingForPotentiallyDangObj.Web.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IRepository<Inspector> _repositoryInspector;
        private readonly IJournalPdoService _journalPdoService;
        private readonly IMapperConfig _mapperConfig;

        //public HomeController(IRepository<Inspector> repositoryInspector)
        //{
        //    _repositoryInspector = repositoryInspector;
        //}
        public HomeController(IJournalPdoService journalPdoService, IMapperConfig mapperConfig)
        {
            _journalPdoService = journalPdoService;
            _mapperConfig = mapperConfig;
        }

        public IActionResult Index()
        {
            var journalsPdoDto = _journalPdoService.GetAllAsync();
            var modelsView = _mapperConfig.Mapper.Map<IEnumerable<JournalPdoViewModel>>(journalsPdoDto);

            return View(modelsView);
        }

        public IActionResult IndexOne()
        {
            var journalsPdoDto = _journalPdoService.GetAllAsync();
            var modelsView = _mapperConfig.Mapper.Map<IEnumerable<JournalPdoViewModel>>(journalsPdoDto);

            return View(modelsView);
        }

        public IActionResult Inspectors()
        {
            var inspectors = _repositoryInspector.GetAll().AsEnumerable();
            return View(inspectors);
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