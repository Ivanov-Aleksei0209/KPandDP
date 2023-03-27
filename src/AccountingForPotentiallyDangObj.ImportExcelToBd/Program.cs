using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace AccountingForPotentiallyDangObj.ImportExcelToBd
{
    internal class Program
    {
        public static void ConvertXlsFileToJsonFile(string pathXlsFile, string pathJsonFile) //string pathXlsFile, string pathJsonFile
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

            var jsonObjectChildrenArray = jsonObject["2022.12.02 Список ПОО"];

            var jsonObjectChildrenList = jsonObjectChildrenArray.Select(x => new Model
            {
                Subject = (string)x["Subject"],
            postalAddress = (string)x["postalAddress"],
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
            

            Serialize(jsonObject);

            List<Model> models = JsonConvert.DeserializeObject<List<Model>>(jsonString);
            //List<Model> models = JsonConvert.DeserializeObject<List<Model>>(jsonString);
        }

        const string filePath = @"c:\dump\json.txt";

        public static void Serialize(object obj)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj);
            }
        }
        public static object Deserialize(string path)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamReader(path))
            using (var reader = new JsonTextReader(sw))
            {
                return serializer.Deserialize(reader);
            }
        }

        //public IActionResult Reader()
        //{
        //    string filePath = @"c:\dump\pdo.json";
        //    string jsonString = File.ReadAllText(filePath);
        //    StreamReader reader = new StreamReader(filePath);
        //    var json = reader.ReadToEnd();
        //    List<Model> models = JsonSerializer.Deserialize<List<Model>>(json);

        //    return View();
        //}
        //public string pathXlsFile = "D:\\GitHub\\KPandDP\\docs\\PdoForDataBaseFifty.xlsx";
        //public string pathJsonFile = "c:\\dump\\PdoForDataBaseFifty.json";
        static void Main(string[] args)
        {
             string pathXlsFile = "D:\\GitHub\\KPandDP\\docs\\PdoForDataBaseFifty.xlsx";
             string pathJsonFile = "c:\\dump\\PdoForDataBaseFifty.json";
        //string json = @"{ CPU: 'Intel', Drives: [ 'DVD read/writer', '500 gigabyte hard drive'  ] }";

        //JObject o = JObject.Parse(json);

        ConvertXlsFileToJsonFile(pathXlsFile, pathJsonFile);
        }
    }
}
