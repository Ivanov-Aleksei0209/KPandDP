using AccountingForPotentiallyDangObj.ImportExcelToDataBase.DtoModels;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.Models;
using Newtonsoft.Json.Linq;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.Services
{
    internal class ConvertXlsFileToJObjectsService
    {
        public static JObject ConvertXlsFileToJson(string pathXlsFile)
        {
            ExcelEngine excelEngine = new ExcelEngine();

            //Instantiate the Excel application object.
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;

            //Load the input Excel file
            FileStream stream = new FileStream(pathXlsFile, FileMode.Open, FileAccess.ReadWrite);
            IWorkbook book = application.Workbooks.Open(stream);
            stream.Close();

            //Access first worksheet
            IWorksheet worksheet = book.Worksheets[0];

            MemoryStream jsonStream = new MemoryStream();

            book.SaveAsJson(jsonStream, worksheet); //Save the first worksheet as a JSON stream

            excelEngine.Dispose();

            byte[] json = new byte[jsonStream.Length];

            //Read the Json stream and convert to a Json object
            jsonStream.Position = 0;
            jsonStream.Read(json, 0, (int)jsonStream.Length);
            string jsonString = Encoding.UTF8.GetString(json);
            JObject jsonObject = JObject.Parse(jsonString);

            return jsonObject;
        }

        public static List<SubjectExcelModel> ConvertXlsFileToJObjectsSubjects(string pathXlsFile)
        {
            var jsonObject = ConvertXlsFileToJson(pathXlsFile);

            var jsonObjectChildrenArray = jsonObject["2022.12.02 Список ПОО"];

            var jsonObjectChildrenList = jsonObjectChildrenArray.Select(x => new SubjectExcelModel
            {
                Subject = (string)x["Subject"],
                PostalAddress = (string)x["PostalAddress"]
            }).ToList();

            return jsonObjectChildrenList;
              
        }

        public static List<ExcelModel> ConvertXlsFileToJObjects(string pathXlsFile)
        {
            var jsonObject = ConvertXlsFileToJson(pathXlsFile);

            var jsonObjectChildrenArray = jsonObject["2022.12.02 Список ПОО"];

            var jsonObjectChildrenList = jsonObjectChildrenArray.Select(x => new ExcelModel
            {
                Subject = (string)x["Subject"],
                InstallationLocation = (string)x["InstallationLocation"],
                JournalPdo = (int)x["JournalPdo"],
                RegistrationNumber = (int)x["RegistrationNumber"],
                TypeOfPdoAbb = (string)x["TypeOfPdoAbb"],
                TypeOfPdoName = (string)x["TypeOfPdoName"],
                ServiceLife = (int)x["ServiceLife"],
                YearOfManufacture = (int)x["YearOfManufacture"],
                DateOfRegistration = (string)x["DateOfRegistration"],
                TechnicalConditional = (string)x["TechnicalConditional"],
                Inspector = (string)x["Inspector"],
                InformationAboutTheTechnicalInspection = (string)x["InformationAboutTheTechnicalInspection"],
                Capacity = (double)x["Capacity"],
                ArrowDeparture = (double)x["ArrowDeparture"],
                NumberOfStops = (int)x["NumberOfStops"],
                Speed = (double)x["Speed"]
            }).ToList();

            return jsonObjectChildrenList;
        }

    }
}
