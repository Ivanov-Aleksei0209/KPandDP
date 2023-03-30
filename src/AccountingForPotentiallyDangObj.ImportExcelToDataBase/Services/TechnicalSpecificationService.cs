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
        public List<TechnicalSpecificationDto> GetTechnicalSpecificationFrom(List<PdoExcelModel> jsonObjectChildrenList)
        {


            var technicalSpecificationsDtoModel = new List<TechnicalSpecificationDto>();
            foreach (var item in jsonObjectChildrenList)
            {
                var technicalSpecificationDtoModel = new TechnicalSpecificationDto();
                technicalSpecificationDtoModel.NumberOfStops = jsonObjectChildrenList.Select(x => x.NumberOfStops).FirstOrDefault();
                technicalSpecificationDtoModel.ArrowDeparture = jsonObjectChildrenList.Select(x => item.ArrowDeparture).FirstOrDefault();
                technicalSpecificationDtoModel.Capacity = jsonObjectChildrenList.Select(x => item.Capacity).FirstOrDefault();
                technicalSpecificationDtoModel.Speed = jsonObjectChildrenList.Select(x => item.Speed).FirstOrDefault();
                technicalSpecificationDtoModel.RegistrationNumber = jsonObjectChildrenList.Select(x => item.RegistrationNumber).FirstOrDefault();
                technicalSpecificationsDtoModel.Add(technicalSpecificationDtoModel);
            }
            
            return technicalSpecificationsDtoModel;
        }
    }
}
