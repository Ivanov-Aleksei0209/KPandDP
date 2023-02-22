using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.Web.DtoModels;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface IJournalPdoService
    {
        IEnumerable<JournalPdoDto> GetAllAsync();
    }
}
