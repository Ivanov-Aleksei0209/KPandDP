using AccountingForPotentiallyDangObj.Web.DtoModels;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface IPdoService
    {
        IEnumerable<PdoDto> GetAllAsync();
    }
}
