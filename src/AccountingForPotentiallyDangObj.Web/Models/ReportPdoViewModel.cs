namespace AccountingForPotentiallyDangObj.Web.Models
{
    public class ReportPdoViewModel
    {
        public string NamePdo { get; set; }
        public string TypePdoName { get; set; }
        public int Quantity { get; set; }
        public int QuantityOld { get; set; }
        public int QuantityJournalPdo { get; set; }
        public int QuantityJournalPdoOld { get; set; }
        public double PercentOld { get; set; }
        public double PercentJournalPdoOld { get; set; }
        public int SumQuantityJournalPdo { get; set; }
        public string NameJournal { get; set; }
        public int JournalNumber { get; set; }
    }
}
