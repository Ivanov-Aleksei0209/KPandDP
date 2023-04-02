using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.Web.DtoModels
{
    public class PdoDto
    {
        public int Id { get; set; }
        //public string? Name { get; set; } = string.Empty;
        public int JournalPdoId { get; set; }
        public int JournalNumber { get; set; }
        public int RegistrationNumber { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public DateOnly DateOfRegistryDateOnly => DateOnly.FromDateTime(DateOfRegistration);
        public int YearOfManufacture { get; set; }
        public TechnicalSpecification TechnicalSpecification { get; set; }
        public int TechnicalSpecificationId { get; set; }
        public int ServiceLife { get; set; }
        public DateTime InformationAboutTheTechnicalInspection { get; set; }
        public DateOnly InformationAboutTheTechnicalInspectionDateOnly => DateOnly.FromDateTime(InformationAboutTheTechnicalInspection);
        public int? InspectorId { get; set; }
        public string? InspectorName { get; set; }
        public int TechnicalConditionalId { get; set; }
        public string TechnicalConditionalName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int InstallationLocationId { get; set; }
        public string? InstallationLocation { get; set; }
        public InstallationLocation InstallationLocationTable { get; set; }
        public DateTime WithdrawalFromRegistration { get; set; }
        public DateOnly WithdrawalFromRegistrationDateOnly => DateOnly.FromDateTime(WithdrawalFromRegistration);
    }
}
