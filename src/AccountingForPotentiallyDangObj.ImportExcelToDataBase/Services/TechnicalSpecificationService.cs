using AccountingForPotentiallyDangObj.DataAccess.AfPdoRepository;
using AccountingForPotentiallyDangObj.DataAccess.EF;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using AccountingForPotentiallyDangObj.DataAccess.Models;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.DtoModels;
using AccountingForPotentiallyDangObj.ImportExcelToDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.Services
{
    public class TechnicalSpecificationService
    {
        private readonly IRepository<TechnicalSpecification> _repositoryTechnicalSpecification;
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AccountingForPotentiallyDangObj.DataBase;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public TechnicalSpecificationService()
        {
            var dbContext = new AfPdoDbContext(_connectionString);
            _repositoryTechnicalSpecification = new AfPdoRepository<TechnicalSpecification>(dbContext);
        }

        public async Task<TechnicalSpecification> AddTechnicalSpecificationAsync(TechnicalSpecification technicalSpecificationModel)
        {
            await _repositoryTechnicalSpecification.AddAsync(technicalSpecificationModel);
            return technicalSpecificationModel;
        }



        public async Task<List<TechnicalSpecification>> AddTechnicalSpecificationsAsync(List<TechnicalSpecification> technicalSpecificationModels)
        {
            foreach (var technicalSpecificationModel in technicalSpecificationModels)
            {

                await _repositoryTechnicalSpecification.AddAsync(technicalSpecificationModel);

            }
            return technicalSpecificationModels;
        }
        //public List<TechnicalSpecificationDto> GetTechnicalSpecificationFrom(List<PdoExcelModel> jsonObjectChildrenList)
        //{


        //    var technicalSpecificationsDtoModel = new List<TechnicalSpecificationDto>();
        //    foreach (var item in jsonObjectChildrenList)
        //    {
        //        var technicalSpecificationDtoModel = new TechnicalSpecificationDto();
        //        technicalSpecificationDtoModel.NumberOfStops = jsonObjectChildrenList.Select(x => x.NumberOfStops).FirstOrDefault();
        //        technicalSpecificationDtoModel.ArrowDeparture = jsonObjectChildrenList.Select(x => item.ArrowDeparture).FirstOrDefault();
        //        technicalSpecificationDtoModel.Capacity = jsonObjectChildrenList.Select(x => item.Capacity).FirstOrDefault();
        //        technicalSpecificationDtoModel.Speed = jsonObjectChildrenList.Select(x => item.Speed).FirstOrDefault();
        //        technicalSpecificationDtoModel.RegistrationNumber = jsonObjectChildrenList.Select(x => item.RegistrationNumber).FirstOrDefault();
        //        technicalSpecificationsDtoModel.Add(technicalSpecificationDtoModel);
        //    }
            
        //    return technicalSpecificationsDtoModel;
        //}
    }
}
