using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class TechnicalSpecification : BaseModel
    {
        public double Capacity { get; set; }
        public double ArrowDeparture { get; set; }
        public double Speed { get; set; }
        public int NumberOfStops { get; set; }        
    }
}
