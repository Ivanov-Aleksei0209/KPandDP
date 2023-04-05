using static System.Net.Mime.MediaTypeNames;
using System.Text;
using Syncfusion.XlsIO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.DtoModels;
using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.Interfaces;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.Services;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase
{
    public class Program
    {
        static void Main(string[] args)
        {

            // Insert Subjects from XlsFile
            string pathXlsFileSubject = "E:\\GitHub\\KPandDP\\docs\\Subjects.xlsx";

            var subjectJObject = ConvertXlsFileToJObjectsService.ConvertXlsFileToJObject(pathXlsFileSubject);

            var subjectExcelModel = new MappingSubjectService();
            var subjectsExcelModels = subjectExcelModel.MapJObjectsToSubjectExcelModels(subjectJObject);

            var subjectDtoModel = new MappingSubjectService();
            var subjectsDtoModels = subjectDtoModel.MapSubjectExelModelsToSubjectsDto(subjectsExcelModels);

            var subjectModel = new MappingSubjectService();
            var subjectsModels = subjectModel.MapSubjectDtoModelsToSubjectModels(subjectsDtoModels);

            var subjectModelDb = new SubjectService();
            var subjectsModelsDb = subjectModelDb.AddSubjectAsync(subjectsModels).Result; 

            // Insert Pdo from XlsFile

            string pathXlsFile = "E:\\GitHub\\KPandDP\\docs\\PdoForDataBase.xlsx";

            var pdoJObject = ConvertXlsFileToJObjectsService.ConvertXlsFileToJObject(pathXlsFile);

            var pdoExcelModel = new MappingPdoService();
            var pdoExcelModels = pdoExcelModel.MapJObjectsToPdoExcelModels(pdoJObject);

            var pdoDtoModel = new MappingPdoService();
            var pdoDtoModels = pdoDtoModel.MapPdoExelModelsToPdoDtoModels(pdoExcelModels);

            var pdoModel = new MappingPdoService();
            var pdoModels = pdoModel.MapPdoDtoModelsToPdoModels(pdoDtoModels);

            var pdoModelDb = new PdoService();
            var pdoModelsDb = pdoModelDb.AddPdoAsync(pdoModels).Result; 
        }
    }
}