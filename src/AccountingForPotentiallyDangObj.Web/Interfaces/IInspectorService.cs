using AccountingForPotentiallyDangObj.Web.DtoModels;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface IInspectorService
    {
        IEnumerable<PdoDto> GetAllAsync();
    }
}
