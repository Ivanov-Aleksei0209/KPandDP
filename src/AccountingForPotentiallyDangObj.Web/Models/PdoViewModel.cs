using AccountingForPotentiallyDangObj.DataAccess.Models;
using System.ComponentModel;

namespace AccountingForPotentiallyDangObj.Web.Models
{
    public class PdoViewModel
    {
        public int Id { get; set; }
        //public string? Name { get; set; } = string.Empty;

        [DisplayName("ID Журнал ПОО")]
        public int JournalPdoId { get; set; }
        [DisplayName("Журнал ПОО")]
        public int JournalNumber { get; set; }

        [DisplayName("Рег. №")]
        public int RegistrationNumber { get; set; }

        [DisplayName("ID Тип ПОО")]
        public int TypeId { get; set; }

        [DisplayName("Тип ПОО")]
        public string TypeName { get; set; }

        [DisplayName("Дата регистрации")]
        public DateOnly DateOfRegistration { get; set; }

        [DisplayName("Год выпуска")]
        public int YearOfManufacture { get; set; }

        [DisplayName("Технические характеристики")]
        public TechnicalSpecification TechnicalSpecification { get; set; }
        public int TechnicalSpecificationId { get; set; }

        [DisplayName("Срок службы")]
        public int ServiceLife { get; set; }

        [DisplayName("Дата ТО")]
        public DateOnly InformationAboutTheTechnicalInspection { get; set; }

        [DisplayName("Инспектор")]
        public string? InspectorName { get; set; }

        [DisplayName("ID Инспектор")]
        public int? InspectorId { get; set; }

        [DisplayName("ID Техническое состояние")]
        public int TechnicalConditionalId { get; set; }

        [DisplayName("Техническое состояние")]
        public string TechnicalConditionalName { get; set; }

        [DisplayName("ID Владелец")]
        public int SubjectId { get; set; }

        [DisplayName("Владелец")]
        public string SubjectName { get; set; }

        [DisplayName("Место установки")]
        public int InstallationLocationId { get; set; }
        public InstallationLocation InstallationLocation { get; set; }

        [DisplayName("Дата снятия")]
        public DateOnly WithdrawalFromRegistration { get; set; }
        public string Clear { get; set; }
    }
}
