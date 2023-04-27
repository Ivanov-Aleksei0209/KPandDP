using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.Web.DtoModels
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UNP { get; set; }
        public int DepartmentalAffiliationId { get; set; }
        public string DepartmentalAffiliationName { get; set; }
        public DepartmentalAffiliation DepartmentalAffiliation { get; set; }
        public string postalAddress { get; set; }
        public string phone { get; set; }
    }
}
