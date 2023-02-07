using AccountingForPotentiallyDangObj.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly IRepository<Inspector> _repositoryInspector;
        private readonly IRepository<JournalPDO> _repositoryJournalPDO;

        //public HomeController(IRepository<Inspector> repositoryInspector)
        //{
        //    _repositoryInspector = repositoryInspector;
        //}
        public HomeController(IRepository<JournalPDO> repositoryJournalPDO)
        {
            _repositoryJournalPDO = repositoryJournalPDO;
        }

        public IActionResult Index()
        {
            var journalPDO = _repositoryJournalPDO.GetAll().AsEnumerable();

            return View(journalPDO);
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