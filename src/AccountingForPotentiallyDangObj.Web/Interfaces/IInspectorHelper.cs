using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Models;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface IInspectorHelper
    {
        Task<InspectorDto> GetInspectorDtoForCreate(InspectorViewModel model);

        Task<InspectorDto> GetInspectorDtoByIdAsync(int id);

        Task<InspectorDto> GetInspectorDtoForUpdateAsync(InspectorViewModel model);
    }
}
