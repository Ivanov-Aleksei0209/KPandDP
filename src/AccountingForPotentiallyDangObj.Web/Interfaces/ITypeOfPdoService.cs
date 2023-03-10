using AccountingForPotentiallyDangObj.Web.DtoModels;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface ITypeOfPdoService
    {
        IEnumerable<PdoDto> GetAllAsync();
    }
}
