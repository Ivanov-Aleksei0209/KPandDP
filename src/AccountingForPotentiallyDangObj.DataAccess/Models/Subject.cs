using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class Subject : BaseModel
    {
        public int UNP { get; set; }
        public int? DepartmentalAffiliationId { get; set; }
        public DepartmentalAffiliation DepartmentalAffiliation { get; set; }
        public string PostalAddress { get; set; }
        public string? Phone { get; set; }        
    }
}
