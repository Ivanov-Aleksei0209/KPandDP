using AccountingForPotentiallyDangObj.Web.DtoModels;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface IPdoService
    {
        IEnumerable<PdoDto> GetAllPdoAsync();
        public IEnumerable<ReportPdoDto> GetReportPdo();
    }
}
