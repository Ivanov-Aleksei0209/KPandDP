using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Models;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface IInspectorService
    {
        IEnumerable<InspectorDto> GetAllInspectorAsync();

        Task<InspectorDto> CreateInspectorAsync(InspectorDto modelDto);

        Task<InspectorDto> UpdateInspectorAsync(InspectorDto modelDto);
    }
}
