using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class PDO
    {
        [Key]
        public int Id { get; set; }
        public int JournalPdoId { get; set; }
        public int RegistrationNumber { get; set; }
        public int TypeId { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public int YearOfManufacture { get; set; }
        public int TechnicalSpecificationId { get; set; }
        public int ServiceLife { get; set; }
        public DateTime InformationAboutTheTechnicalInspection { get; set; }
        public int InspectorId { get; set; }
        public int TechnicalConditionalId { get; set; }
        public int SubjectId { get; set; }
        public int InstallationLocationId { get; set; }
    }
}
