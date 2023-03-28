using AccountingForPotentiallyDangObj.ImportExcelToDataBase.DtoModels;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.Models;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.Interfaces
{
    public interface ISubjectService
    {
        void AddAllSubjectAsync(List<SubjectDto> subjectsDtoModel);
        List<SubjectDto> GetSubjectFrom(List<SubjectExcelModel> jsonObjectChildrenList);        
    }
}
