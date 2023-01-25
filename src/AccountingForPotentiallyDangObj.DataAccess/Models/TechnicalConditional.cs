using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using AccountingForPotentiallyDangObj.DataAccess.Interfaces;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
   public class TechnicalConditional : BaseModel
    {
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return obj is TechnicalConditional technicalConditional &&
                Id == technicalConditional.Id &&
                Name == technicalConditional.Name;
        }
        public override int GetHashCode() => Tuple.Create(Id, Name).GetHashCode();
    }
}
