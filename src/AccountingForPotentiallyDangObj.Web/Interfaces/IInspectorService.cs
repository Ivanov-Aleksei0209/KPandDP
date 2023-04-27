using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Models;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface IInspectorService
    {
        IEnumerable<InspectorDto> GetAllInspectorAsync();
        Task<InspectorDto> AddNewInspectorAsync(InspectorDto modelDto);
        Task<InspectorDto> MapInspectorViewModelToInspectorDto(InspectorViewModel model);
    }
}
