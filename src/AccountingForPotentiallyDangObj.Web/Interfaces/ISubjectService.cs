using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Models;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<SubjectDto> GetAllSubjectAsync();
        Task<SubjectDto> AddNewSubjectAsync(SubjectDto modelDto);
        Task<SubjectDto> MapSubjectViewModelToSubjectDto(SubjectViewModel model);
    }
}
