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

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return obj is TechnicalSpecification technicalSpecification &&
                Id == technicalSpecification.Id &&
                Capacity == technicalSpecification.Capacity &&
                ArrowDeparture == technicalSpecification.ArrowDeparture &&
                NumberOfStops == technicalSpecification.NumberOfStops;                    
        }
        public override int GetHashCode() => Tuple.Create(Id, Capacity, ArrowDeparture, Speed, NumberOfStops).GetHashCode();
      

    }
}
