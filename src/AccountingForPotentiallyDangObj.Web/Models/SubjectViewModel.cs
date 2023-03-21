using AccountingForPotentiallyDangObj.DataAccess.Models;

namespace AccountingForPotentiallyDangObj.Web.Models
{
    public class SubjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UNP { get; set; }
        public int departmentalAffiliationId { get; set; }
        public DepartmentalAffiliation DepartmentalAffiliation { get; set; }
        public string postalAddress { get; set; }
        public string phone { get; set; }
    }
}
