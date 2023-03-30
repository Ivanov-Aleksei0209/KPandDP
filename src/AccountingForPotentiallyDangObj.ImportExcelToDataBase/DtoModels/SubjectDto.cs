using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.DtoModels
{
    public class SubjectDto
    {
        //public int Id { get; set; }
        public string Subject { get; set; }
        public string? UNP { get; set; }
        //public int departmentalAffiliationId { get; set; }
        //public string departmentalAffiliationName { get; set; }
        //public DepartmentalAffiliation DepartmentalAffiliation { get; set; }
        public string PostalAddress { get; set; }
        public string? Phone { get; set; }
    }
}
