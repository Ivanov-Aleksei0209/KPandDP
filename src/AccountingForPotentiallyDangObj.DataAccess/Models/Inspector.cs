using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class Inspector : BaseModel

    {
        public int RoleId { get; set; }
        public Role? Role { get; set; } 
    }
    
}
