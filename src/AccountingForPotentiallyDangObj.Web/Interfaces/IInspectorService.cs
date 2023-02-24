using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface IInspectorService
    {
        IEnumerable<InspectorDto> GetAllAsync();
    }
}
