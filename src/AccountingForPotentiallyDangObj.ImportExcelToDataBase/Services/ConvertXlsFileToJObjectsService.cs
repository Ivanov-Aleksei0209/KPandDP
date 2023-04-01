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
        public static JObject ConvertXlsFileToJObject(string pathXlsFile)
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
            JObject jObject = JObject.Parse(jsonString);

            return jObject;
        }
    }
}
