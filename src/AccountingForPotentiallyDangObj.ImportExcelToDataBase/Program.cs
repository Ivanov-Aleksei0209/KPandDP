﻿using static System.Net.Mime.MediaTypeNames;
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
        private readonly IRepository<Subject> _repositorySubject;
        private readonly IMapperConfig _mapperConfig;

        public Program(IRepository<Subject> repositorySubject, IMapperConfig mapperConfig)
        {
            //_repositoryPdo = repositoryPdo;
            //_repositoryJournalPdo = repositoryJournalPdo;
            //_repositoryTypeOfPdo = repositoryTypeOfPdo;
            //_repositoryTechnicalConditional = repositoryTechnicalConditional;
            //_repositoryInspector = repositoryInspector;
            _repositorySubject = repositorySubject;
            _mapperConfig = mapperConfig;
        }
       

        //const string filePath = @"c:\dump\json.txt";

        //public static void Serialize(object obj)
        //{
        //    var serializer = new JsonSerializer();

        //    using (var sw = new StreamWriter(filePath))
        //    using (JsonWriter writer = new JsonTextWriter(sw))
        //    {
        //        serializer.Serialize(writer, obj);
        //    }
        //}
        //public static object Deserialize(string path)
        //{
        //    var serializer = new JsonSerializer();

        //    using (var sw = new StreamReader(path))
        //    using (var reader = new JsonTextReader(sw))
        //    {
        //        return serializer.Deserialize(reader);
        //    }
        //}
        static void Main(string[] args)
        {
            string pathXlsFileSubject = "E:\\GitHub\\KPandDP\\docs\\Subjects.xlsx";
            string pathXlsFile = "E:\\GitHub\\KPandDP\\docs\\PdoForDataBase.xlsx";
            
            // Insert Subjects from XlsFile
            var mainSubjectObject = ConvertXlsFileToJObjectsService.MapJObjectsToExcelModelsSubjects(pathXlsFileSubject);

            var listSubjects = new SubjectService();
            var subjects = listSubjects.GetSubjectFrom(mainSubjectObject);
            var subjectsModels = new SubjectService();
            var models = subjectsModels.MapDtoModelsToModels(subjects);
            
            var subjectsModelsDb = new SubjectService();
            var subjectModelsFromDb = subjectsModelsDb.AddAllSubjectAsync(models).Result;



            // Insert Subjects from XlsFile
            var mainObject = ConvertXlsFileToJObjectsService.ConvertXlsFileToJObjects(pathXlsFile);

            var listTechnicalSpecification = new TechnicalSpecificationService();
            var technicalSpecification = listTechnicalSpecification.GetTechnicalSpecificationFrom(mainObject);

            
        }
    }
}