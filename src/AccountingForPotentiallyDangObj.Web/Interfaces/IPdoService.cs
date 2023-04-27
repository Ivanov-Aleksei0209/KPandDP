using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Models;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface IPdoService
    {
        IEnumerable<PdoDto> GetAllPdoAsync();
        public IEnumerable<ReportPdoDto> GetReportPdo();

        Task<PdoDto> MapPdoViewModelToPdoDto(PdoViewModel model);
        Task<PdoDto> AddNewPdoAsync(PdoDto model);
        Task<PdoDto> EditPdoAsync(PdoDto modelDto);
        Task<PdoDto> MapPdoToPdoDto(int id);
        Task<PdoDto> MapPdoViewModelToPdoDtoUpdate(PdoViewModel model);


    }
}
