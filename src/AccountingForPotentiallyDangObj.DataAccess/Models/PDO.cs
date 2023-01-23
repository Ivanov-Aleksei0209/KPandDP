using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class PDO : BaseModel
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
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return obj is PDO pDO &&
                Id == pDO.Id &&
                JournalPdoId == pDO.JournalPdoId &&
                RegistrationNumber == pDO.RegistrationNumber &&
                TypeId == pDO.TypeId &&
                DateOfRegistration == pDO.DateOfRegistration &&
                YearOfManufacture == pDO.YearOfManufacture &&
                TechnicalSpecificationId == pDO.TechnicalSpecificationId &&
                ServiceLife == pDO.ServiceLife; // &&
                //InformationAboutTheTechnicalInspection == pDO.InformationAboutTheTechnicalInspection &&
                //InspectorId == pDO.InspectorId &&
                //TechnicalConditionalId == pDO.TechnicalConditionalId &&
                //SubjectId == pDO.SubjectId &&
                //InstallationLocationId == pDO.InstallationLocationId;
        }
        public override int GetHashCode() => Tuple.Create(Id, JournalPdoId, RegistrationNumber, TypeId, DateOfRegistration, YearOfManufacture, TechnicalSpecificationId,
                                          ServiceLife).GetHashCode(); 
                                          //InformationAboutTheTechnicalInspection, InspectorId, TechnicalConditionalId, SubjectId, InstallationLocationId).GetHashCode();
    }
}
