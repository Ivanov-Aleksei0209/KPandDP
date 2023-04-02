using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class BaseModel : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
    }
}
