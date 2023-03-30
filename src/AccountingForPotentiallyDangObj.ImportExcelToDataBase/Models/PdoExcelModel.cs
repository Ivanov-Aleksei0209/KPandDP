using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.Models
{
    public class PdoExcelModel
    {
        public string Subject { get; set; }
        public string InstallationLocation { get; set; }
        public int? JournalPdo { get; set; }
        public int RegistrationNumber { get; set; }
        public string? TypeOfPdoAbb { get; set; }
        public string? TypeOfPdoName { get; set; }
        public int? ServiceLife { get; set; }
        public int? YearOfManufacture { get; set; }
        public string? DateOfRegistration { get; set; }
        public string? TechnicalConditional { get; set; }
        public string? Inspector { get; set; }
        public string? InformationAboutTheTechnicalInspection { get; set; }
        public double? Capacity { get; set; }
        public double? ArrowDeparture { get; set; }
        public int? NumberOfStops { get; set; }
        public double? Speed { get; set; }
    }
}
