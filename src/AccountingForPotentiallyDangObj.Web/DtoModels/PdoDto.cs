using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.Web.DtoModels
{
    public class PdoDto
    {
        public int Id { get; set; }

        public int JournalPdoId { get; set; }

        public int JournalNumber { get; set; }

        public int RegistrationNumber { get; set; }

        public int TypeId { get; set; }

        public string TypeName { get; set; }
        public string Abb { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public DateOnly DateOfRegistrationDateOnly => DateOnly.FromDateTime(DateOfRegistration);

        public string DateOfRegistrationString { get; set; }

        public int YearOfManufacture { get; set; }

        public int? YearOfCommissioning { get; set; }

        public TechnicalSpecificationDto TechnicalSpecification { get; set; }

        public int TechnicalSpecificationId { get; set; }

        public string? CapacityString { get; set; }

        public string? ArrowDepartureString { get; set; }

        public string? SpeedString { get; set; }

        public int? NumberOfStops { get; set; }

        public int ServiceLife { get; set; }

        public string? ModelName { get; set; }

        public string? SerialNumber { get; set; }

        public string? Manufacturer { get; set; }

        public DateTime InformationAboutTheLastSurvey { get; set; }

        public DateOnly InformationAboutTheLastSurveyDateOnly => DateOnly.FromDateTime(InformationAboutTheLastSurvey);

        public DateTime InformationAboutTheTechnicalInspection { get; set; }

        public DateOnly InformationAboutTheTechnicalInspectionDateOnly => DateOnly.FromDateTime(InformationAboutTheTechnicalInspection);

        public DateTime InformationAboutTheTechnicalDiagnostic { get; set; }

        public DateOnly InformationAboutTheTechnicalDiagnosticDateOnly => DateOnly.FromDateTime(InformationAboutTheTechnicalDiagnostic);

        public int? InspectorId { get; set; }

        public string? InspectorName { get; set; }

        public int TechnicalConditionalId { get; set; }

        public string TechnicalConditionalName { get; set; }

        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public int InstallationLocationId { get; set; }

        public string? InstallationLocationAddress { get; set; }

        public InstallationLocation InstallationLocation { get; set; }
        public string? InstallationLocationName { get; set; }

        public DateTime? WithdrawalFromRegistrationForDb { get; set; }
        
        public DateTime WithdrawalFromRegistration { get; set; }
  
        public DateOnly WithdrawalFromRegistrationDateOnly => DateOnly.FromDateTime(WithdrawalFromRegistration);
    
        public string? Note { get; set; }
    }
}
