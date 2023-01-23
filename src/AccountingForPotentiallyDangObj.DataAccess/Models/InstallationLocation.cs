using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class InstallationLocation : BaseModel
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
            return obj is InstallationLocation installationLocation &&
                Id == installationLocation.Id &&
                Name == installationLocation.Name;
        }
        public override int GetHashCode() => Tuple.Create(Id, Name).GetHashCode();
    }
}
