using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int UNP { get; set; }
        public int departmentalAffiliationId { get; set; }
        public string postalAddress { get; set; }
        public string phone { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return obj is Subject subject &&
                Id == subject.Id &&
                Name == subject.Name &&
                UNP == subject.UNP &&
                departmentalAffiliationId == subject.departmentalAffiliationId &&
                postalAddress == subject.postalAddress &&
                phone == subject.phone;
        }
        public override int GetHashCode() => Tuple.Create(Id, Name, UNP, departmentalAffiliationId, postalAddress, phone).GetHashCode();
    }
}
