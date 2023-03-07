using AccountingForPotentiallyDangObj.Web.DtoModels;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface ITechnicalConditionalService
    {
        IEnumerable<PdoDto> GetAllAsync();
    }
}
