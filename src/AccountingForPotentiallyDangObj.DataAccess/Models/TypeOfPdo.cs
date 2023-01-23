using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class TypeOfPdo : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abb { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return obj is TypeOfPdo typeOfPdo &&
                Id == typeOfPdo.Id &&
                Name == typeOfPdo.Name &&
                Abb == typeOfPdo.Abb;
        }
        public override int GetHashCode() => Tuple.Create(Id, Name, Abb).GetHashCode();
    }
}
