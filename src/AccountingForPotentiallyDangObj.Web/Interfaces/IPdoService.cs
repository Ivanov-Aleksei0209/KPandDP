using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Models;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface IPdoService
    {
        IEnumerable<PdoDto> GetAllPdoAsync();
        public IEnumerable<ReportPdoDto> GetReportPdo();

        //Task<PdoDto> GetPdoDtoForAddAsync(PdoViewModel model);
        Task<PdoDto> CreatePdoAsync(PdoDto model);
        Task<PdoDto> UpdatePdoAsync(PdoDto modelDto);
        //Task<PdoDto> GetPdoDtoByIdAsync(int id);
        //Task<PdoDto> GetPdoDtoForUpdateAsync(PdoViewModel model);


    }
}
