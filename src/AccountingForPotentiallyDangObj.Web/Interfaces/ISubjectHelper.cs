using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Models;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface ISubjectHelper
    {
        Task<SubjectDto> GetSubjectDtoForCreate(SubjectViewModel model);

        Task<SubjectDto> GetSubjectDtoByIdAsync(int id);

        Task<SubjectDto> GetSubjectDtoForUpdateAsync(SubjectViewModel model);
    }
}
