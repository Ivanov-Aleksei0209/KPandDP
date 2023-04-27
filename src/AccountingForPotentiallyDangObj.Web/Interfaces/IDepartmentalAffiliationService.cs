using AccountingForPotentiallyDangObj.Web.DtoModels;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface IDepartmentalAffiliationService
    {
        IEnumerable<DepartmentalAffiliationDto> GetAllAsync();
    }
}
