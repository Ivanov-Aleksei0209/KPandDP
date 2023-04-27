using AccountingForPotentiallyDangObj.Web.DtoModels;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAllAsync();
    }
}
