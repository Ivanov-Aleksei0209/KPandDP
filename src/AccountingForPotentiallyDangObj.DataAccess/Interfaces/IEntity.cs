using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingForPotentiallyDangObj.DataAccess.Interfaces
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
        string? Name { get; set; }
    }
}
