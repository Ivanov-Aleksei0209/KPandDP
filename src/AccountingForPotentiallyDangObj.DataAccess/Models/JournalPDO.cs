using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class JournalPDO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int JournalNumber { get; set; }
    }
}
