using AccountingForPotentiallyDangObj.Web.DtoModels;
using AccountingForPotentiallyDangObj.Web.Models;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<SubjectDto> GetAllSubjectAsync();

        Task<SubjectDto> CreateSubjectAsync(SubjectDto modelDto);

        Task<SubjectDto> UpdateSubjectAsync(SubjectDto modelDto);
    }
}
