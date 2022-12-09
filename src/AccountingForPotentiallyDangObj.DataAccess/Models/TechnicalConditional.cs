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
    }
}
