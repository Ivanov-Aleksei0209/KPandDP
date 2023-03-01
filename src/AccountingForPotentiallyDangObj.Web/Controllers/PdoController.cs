using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AccountingForPotentiallyDangObj.Web.Infrastructure;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Models;

namespace AccountingForPotentiallyDangObj.Web.Controllers
{
    public class PdoController : Controller
    {
        private readonly IPdoService _pdoService;
        private readonly IMapperConfig _mapperConfig;
        public PdoController(IPdoService pdoService, IMapperConfig mapperConfig)
        {
            _pdoService = pdoService;
            _mapperConfig = mapperConfig;
        }
        public IActionResult Pdo()
        { 
            var pdoDto = _pdoService.GetAllAsync();
            var modelsView = _mapperConfig.Mapper.Map<IEnumerable<PdoViewModel>>(pdoDto);
            return View(modelsView);
        }
    }
}
