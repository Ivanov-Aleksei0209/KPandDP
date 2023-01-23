using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class JournalPDO : BaseModel
    {
        public int JournalNumber { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return obj is JournalPDO journalPDO &&
                Id == journalPDO.Id &&
                Name == journalPDO.Name &&
                JournalNumber == journalPDO.JournalNumber;
        }
        public override int GetHashCode() => Tuple.Create(Id, Name).GetHashCode();
    }
}
