﻿using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.DtoModels
{
    public class PdoDto
    {
        public string Subject { get; set; }
        public string? InstallationLocationAddress { get; set; }
        public int JournalPdo { get; set; }
        public int RegistrationNumber { get; set; }
        public string? TypeOfPdoAbb { get; set; }
        public string? TypeOfPdoName { get; set; }
        public string? Model { get; set; }
        public int? ServiceLife { get; set; }
        public int? YearOfManufacture { get; set; }
        public string? DateOfRegistration { get; set; }
        public int? YearOfCommissioning { get; set; }
        public string? SerialNumber { get; set; }
        public string? Manufacturer { get; set; }
        public string? TechnicalConditional { get; set; }
        public string? Inspector { get; set; }
        public string? InformationAboutTheLastSurvey { get; set; }
        public string? InformationAboutTheTechnicalInspection { get; set; }
        public string? InformationAboutTheTechnicalDiagnostic { get; set; }
        public double? Capacity { get; set; }
        public string? Note { get; set; }
        public double? ArrowDeparture { get; set; }
        public int? NumberOfStops { get; set; }
        public double? Speed { get; set; }
    }
}
