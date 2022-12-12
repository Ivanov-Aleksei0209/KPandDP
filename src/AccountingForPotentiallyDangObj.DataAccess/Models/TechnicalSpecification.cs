using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class TechnicalSpecification
    {
        [Key]
        public int Id { get; set; }
        public double Capacity { get; set; }
        public double ArrowDeparture { get; set; }
        public double Speed { get; set; }
        public int NumberOfStops { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is TechnicalSpecification technicalSpecification)
            {
                return Id == technicalSpecification.Id;
            }
            return false;                
        }


    }
}
