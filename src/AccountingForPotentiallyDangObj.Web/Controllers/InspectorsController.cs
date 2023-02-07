using AccountingForPotentiallyDangObj.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.Web.Controllers
{
    public class InspectorsController : Controller
    {
        private readonly IRepository<Inspector> _repositoryInspector;
        public InspectorsController(IRepository<Inspector> repositoryInspector)
        {
            _repositoryInspector = repositoryInspector;
        }
       
        public IActionResult Inspectors()
        {
            var inspectors = _repositoryInspector.GetAll().AsEnumerable();
            return View(inspectors);
        }
    }
}
