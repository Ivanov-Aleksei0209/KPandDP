﻿using AccountingForPotentiallyDangObj.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class JournalPdo : BaseModel
    {
        public int JournalNumber { get; set; }

    }
}
