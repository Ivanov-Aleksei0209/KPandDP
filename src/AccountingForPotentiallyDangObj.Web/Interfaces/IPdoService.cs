using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface IPdoService
    {
        IEnumerable<PdoDto> GetAllPdoAsync();
        public IEnumerable<ReportPdoDto> GetReportPdo();
        Task<PdoDto> AddNewPdoAsync(PdoDto model);
        Task<IEnumerable<PdoDto>> EditPdoAsync(int id);
    }
}
