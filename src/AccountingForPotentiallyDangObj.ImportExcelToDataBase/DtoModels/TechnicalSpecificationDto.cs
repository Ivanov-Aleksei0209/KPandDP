using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.DtoModels
{
    public class TechnicalSpecificationDto
    {
        public int Id { get; set; }
        //public string Name { get; set; }
        public double? Capacity { get; set; }
        public double? ArrowDeparture { get; set; }
        public double? Speed { get; set; }
        public int? NumberOfStops { get; set; }
        public int RegistrationNumber { get; set; }
    }
}
