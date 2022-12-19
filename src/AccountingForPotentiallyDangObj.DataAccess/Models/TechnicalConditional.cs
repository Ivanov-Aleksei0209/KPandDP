using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
   public class TechnicalConditional
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
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
