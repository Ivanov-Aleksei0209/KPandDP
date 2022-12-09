﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public int UNP { get; set; }
        public int departmentalAffiliationId { get; set; }
        public string postalAddress { get; set; }
        public string phone { get; set; }
    }
}
