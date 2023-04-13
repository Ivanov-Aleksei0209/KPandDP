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
        public string RegistrationNumberString
        {
            get
            {
                if (RegistrationNumber.ToString().Length == 1)
                {
                    return $"000{RegistrationNumber}";
                }
                if (RegistrationNumber.ToString().Length == 2)
                {
                    return $"00{RegistrationNumber}";
                }
                if (RegistrationNumber.ToString().Length == 3)
                {
                    return $"0{RegistrationNumber}";
                }
                return RegistrationNumber.ToString();
            }
        }


        [DisplayName("ID Тип ПОО")]
        public int TypeId { get; set; }

        [DisplayName("Тип ПОО")]
        public string TypeName { get; set; }

        [DisplayName("Дата регистрации")]
        public DateOnly DateOfRegistration { get; set; }

        [DisplayName("Год выпуска")]
        public int YearOfManufacture { get; set; }

        [DisplayName("Модель")]
        public string? Model { get; set; }

        [DisplayName("Заводской номер")]
        public string? SerialNumber { get; set; }

        [DisplayName("Изготовитель")]
        public string? Manufacturer { get; set; }

        [DisplayName("Технические характеристики")]
        public TechnicalSpecification TechnicalSpecification { get; set; }
        public int TechnicalSpecificationId { get; set; }

        [DisplayName("Срок службы")]
        public int ServiceLife { get; set; }

        [DisplayName("Последнее обследование")]
        public DateOnly InformationAboutTheLastSurvey { get; set; }
        public string InformationAboutTheLastSurveyString
        {
            get
            {
                if (InformationAboutTheLastSurvey.ToString() == "01.01.0001")
                {
                    return "";
                }
                return InformationAboutTheLastSurvey.ToString();
            }
        }

        [DisplayName("Дата ТО")]
        public DateOnly InformationAboutTheTechnicalInspection { get; set; }
        public string InformationAboutTheTechnicalInspectionString
        {
            get
            {
                if (InformationAboutTheTechnicalInspection.ToString() == "01.01.0001")
                {
                    return "";
                }
                return InformationAboutTheTechnicalInspection.ToString();
            }
        }
        [DisplayName("Дата ТД")]
        public DateOnly InformationAboutTheTechnicalDiagnostic { get; set; }
        public string InformationAboutTheTechnicalDiagnosticString
        {
            get
            {
                if (InformationAboutTheTechnicalDiagnostic.ToString() == "01.01.0001")
                {
                    return "";
                }
                return InformationAboutTheTechnicalDiagnostic.ToString();
            }
        }

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
        public string? InstallationLocationAddress { get; set; }
        public int InstallationLocationId { get; set; }
        public InstallationLocation InstallationLocation { get; set; }

        [DisplayName("Дата снятия")]
        public DateOnly WithdrawalFromRegistration { get; set; }
        public string WithdrawalFromRegistrationString
        {
            get
            {
                if (WithdrawalFromRegistration.ToString() == "01.01.0001")
                {
                    return "";
                }
                return WithdrawalFromRegistration.ToString();
            }
        }
    }
}
