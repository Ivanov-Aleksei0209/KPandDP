using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class Pdo : BaseModel
    {
        public int JournalPdoId { get; set; }
        public int? RegistrationNumber { get; set; }
        public int TypeId { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public TechnicalSpecification TechnicalSpecification { get; set; }
        public int? TechnicalSpecificationId { get; set; }
        public int? ServiceLife { get; set; }
        public int? InspectorId { get; set; }
        public Inspector Inspector { get; set; }
        public int? TechnicalConditionalId { get; set; }
        public TechnicalConditional TechnicalConditional { get; set; }
        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int? InstallationLocationId { get; set; }
        public InstallationLocation InstallationLocation { get; set; }
        public string? InstallationLocationAddress { get; set; }
        public int? YearOfManufacture { get; set; }
        public int? YearOfCommissioning { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }
        public string? Manufacturer { get; set; }
        public DateTime? InformationAboutTheLastSurvey { get; set; }
        public DateTime? InformationAboutTheTechnicalInspection { get; set; }
        public DateTime? InformationAboutTheTechnicalDiagnostic { get; set; }
        public DateTime? WithdrawalFromRegistration { get; set; }
        public string? Note { get; set; }
    }
}
