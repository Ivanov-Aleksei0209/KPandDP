using AccountingForPotentiallyDangObj.Web.DtoModels;

namespace AccountingForPotentiallyDangObj.Web.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<SubjectDto> GetAllSubjectAsync();
    }
}
