using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class Pdo : BaseModel
    {
        public int JournalPdoId { get; set; }
        public int RegistrationNumber { get; set; }
        public int TypeId { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public int YearOfManufacture { get; set; }
        public TechnicalSpecification TechnicalSpecification { get; set; }  
        public int TechnicalSpecificationId { get; set; }
        public int ServiceLife { get; set; }
        public DateTime InformationAboutTheTechnicalInspection { get; set; }
        public int InspectorId { get; set; }
        public int TechnicalConditionalId { get; set; }
        public int SubjectId { get; set; }
        public int InstallationLocationId { get; set; }
        public InstallationLocation InstallationLocation { get; set; }
    }
}
