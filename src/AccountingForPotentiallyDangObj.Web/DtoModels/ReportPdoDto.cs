namespace AccountingForPotentiallyDangObj.Web.DtoModels
{
    public class ReportPdoDto
    {
        //public string NamePdo { get; set; }
        //public string TypePdoName { get; set; }
        public int Quantity { get; set; }
        public int QuantityOld { get; set; }
        public int QuantityAll { get; set; }
        public int QuantityAllOld { get; set; }
        public double PercentOld { get; set; }
        public double PercentAllOld { get; set; }
        //public int SumQuantityJournalPdo { get; set; }
        public string NameJournal { get; set; }
        public string? NameType { get; set; }
        //public int JournalNumber { get; set; }
        //public int JournalNumberId { get; set; }

    }
}
