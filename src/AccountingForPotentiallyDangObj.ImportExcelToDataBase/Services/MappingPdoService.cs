using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.DtoModels;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.Interfaces;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.Services
{
    public class MappingPdoService
    {
        private readonly IRepository<Subject> _repositorySubject;
        private readonly IRepository<Pdo> _repositoryPdo;
        private readonly IRepository<JournalPdo> _repositoryJournalPdo;
        private readonly IRepository<TypeOfPdo> _repositoryTypeOfPdo;
        private readonly IRepository<TechnicalConditional> _repositoryTechnicalConditional;
        private readonly IRepository<Inspector> _repositoryInspector;
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //private readonly IMapperConfig _mapperConfig;

        //public MappingPdoService(IRepository<Subject> repositorySubject, IRepository<Pdo> repositoryPdo, IRepository<JournalPdo> repositoryJournalPdo,
        //IRepository<TypeOfPdo> repositoryTypeOfPdo, IRepository<TechnicalConditional> repositoryTechnicalConditional,
        //    IRepository<Inspector> repositoryInspector, IMapperConfig mapperConfig) { }
        public MappingPdoService()
        {
            var dbContext = new AfPdoDbContext(_connectionString);
            _repositorySubject = new AfPdoRepository<Subject>(dbContext);
            _repositoryPdo = new AfPdoRepository<Pdo>(dbContext); ;
            _repositoryJournalPdo = new AfPdoRepository<JournalPdo>(dbContext); ;
            _repositoryTypeOfPdo = new AfPdoRepository<TypeOfPdo>(dbContext); ;
            _repositoryTechnicalConditional = new AfPdoRepository<TechnicalConditional>(dbContext); ;
            _repositoryInspector = new AfPdoRepository<Inspector>(dbContext); ;
            //_repositoryPdo = repositoryPdo;
            //_repositoryJournalPdo = repositoryJournalPdo;
            //_repositoryTypeOfPdo = repositoryTypeOfPdo;
            //_repositoryTechnicalConditional = repositoryTechnicalConditional;
            //_repositoryInspector = repositoryInspector;
            //_repositorySubject = repositorySubject;
            //_mapperConfig = mapperConfig;
        }
        public List<PdoExcelModel> MapJObjectsToPdoExcelModels(JObject jObject)
        {

            var jObjectChildrenArray = jObject["2022.12.02 Список ПОО"];

            var pdoExcelModel = jObjectChildrenArray.Select(x => new PdoExcelModel
            {
                Subject = (string)x["Subject"],
                InstallationLocationAddress = (string)x["InstallationLocationAddress"],
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

            return pdoExcelModel;
        }
        public List<PdoDto> MapPdoExelModelsToPdoDtoModels(List<PdoExcelModel> pdoExcelModel)
        {

            var PdoDtoModel = new List<PdoDto>();
            foreach (var item in pdoExcelModel)
            {
                var pdoDtoModel = new PdoDto();
                pdoDtoModel.Subject = item.Subject;
                pdoDtoModel.InstallationLocationAddress = item.InstallationLocationAddress;
                pdoDtoModel.JournalPdo = item.JournalPdo;
                pdoDtoModel.RegistrationNumber = item.RegistrationNumber;
                pdoDtoModel.TypeOfPdoAbb = item.TypeOfPdoAbb;
                pdoDtoModel.TypeOfPdoName = item.TypeOfPdoName;
                pdoDtoModel.ServiceLife = item.ServiceLife;
                pdoDtoModel.YearOfManufacture = item.YearOfManufacture;
                pdoDtoModel.DateOfRegistration = item.DateOfRegistration;
                pdoDtoModel.TechnicalConditional = item.TechnicalConditional;
                pdoDtoModel.Inspector = item.Inspector;
                pdoDtoModel.InformationAboutTheTechnicalInspection = item.InformationAboutTheTechnicalInspection;
                pdoDtoModel.Capacity = item.Capacity;
                pdoDtoModel.ArrowDeparture = item.ArrowDeparture;
                pdoDtoModel.NumberOfStops = item.NumberOfStops;
                pdoDtoModel.Speed = item.Speed;

                PdoDtoModel.Add(pdoDtoModel);
            }

            return PdoDtoModel;
        }
        //public TechnicalSpecification MapPdoDtoToTechnicalSpecificationModel()
        //{

        //    return TechnicalSpecificationModel;
        //}

        public Pdo MapPdoDtoToPdoModel(PdoDto PdoDtoModel)
        {
            var model = new Pdo();
            var modelsPdo = _repositoryPdo.GetAll().ToList();
            var modelsJournalPdo = _repositoryJournalPdo.GetAll().ToList();
            if (modelsPdo.Select(x => x.RegistrationNumber).Contains(PdoDtoModel.RegistrationNumber) && modelsJournalPdo.Select(x => x.JournalNumber).Contains(PdoDtoModel.JournalPdo)) {
                model.RegistrationNumber = null;
                Console.WriteLine($"ПОО с регистрационным номером {PdoDtoModel.RegistrationNumber} уже существует");
            }
            else { 
            model.RegistrationNumber = PdoDtoModel.RegistrationNumber;
            model.DateOfRegistration = DateTime.Parse(PdoDtoModel.DateOfRegistration);
            model.YearOfManufacture = PdoDtoModel.YearOfManufacture;
            model.ServiceLife = PdoDtoModel.ServiceLife;
            model.InstallationLocationAddress = PdoDtoModel.InstallationLocationAddress;

            if (PdoDtoModel.InformationAboutTheTechnicalInspection != null)
            {
                model.InformationAboutTheTechnicalInspection = DateTime.Parse(PdoDtoModel.InformationAboutTheTechnicalInspection);
            }
                        
            var journalPdoById = modelsJournalPdo.Where(x => x.JournalNumber == PdoDtoModel.JournalPdo).FirstOrDefault();
            model.JournalPdoId = journalPdoById.Id;

            var modelsTypeOfPdo = _repositoryTypeOfPdo.GetAll().ToList();
            var typeOfPdoById = modelsTypeOfPdo.Where(x => x.Abb == PdoDtoModel.TypeOfPdoAbb).FirstOrDefault();
            model.TypeId = typeOfPdoById.Id;

            var modelsTechnicalConditional = _repositoryTechnicalConditional.GetAll().ToList();
            var techCondModelById = modelsTechnicalConditional.Where(x => x.Name == PdoDtoModel.TechnicalConditional).FirstOrDefault();
            model.TechnicalConditionalId = techCondModelById.Id;

            var modelsInspector = _repositoryInspector.GetAll().ToList();
            var inspectorById = modelsInspector.Where(x => x.Name == PdoDtoModel.Inspector).FirstOrDefault();
            model.InspectorId = inspectorById.Id;

            var modelsSubject = _repositorySubject.GetAll().ToList();
            var subjectById = modelsSubject.Where(x => x.Name == PdoDtoModel.Subject).FirstOrDefault();
            model.SubjectId = subjectById.Id;

            var technicalSpecificationModel = new TechnicalSpecification()
            {
                NumberOfStops = PdoDtoModel.NumberOfStops,
                ArrowDeparture = PdoDtoModel.ArrowDeparture,
                Capacity = PdoDtoModel.Capacity,
                Speed = PdoDtoModel.Speed
            };
            var technicalSpecificationService = new TechnicalSpecificationService();
            var technicalSpecificationFromDb = technicalSpecificationService.AddTechnicalSpecificationAsync(technicalSpecificationModel).Result;
            model.TechnicalSpecificationId = technicalSpecificationFromDb.Id;
            }

            return model;

        }


        public List<Pdo> MapPdoDtoModelsToPdoModels(List<PdoDto> pdoDtoModel)
        {
            var models = new List<Pdo>();
            foreach (PdoDto pdoDto in pdoDtoModel)
            {
                var model = MapPdoDtoToPdoModel(pdoDto);
                if (model.RegistrationNumber != null)
                models.Add(model);
            }
            return models;
        }
    }
}
