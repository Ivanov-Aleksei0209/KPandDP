using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class Inspector : BaseModel

    {
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return obj is Inspector inspector &&
                Id == inspector.Id &&
                Name == inspector.Name;
        }
        public override int GetHashCode() => Tuple.Create(Id, Name).GetHashCode();
    }
    
}
