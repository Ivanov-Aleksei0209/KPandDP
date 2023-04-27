using AccountingForPotentiallyDangObj.DataAccess.Models;
using System.ComponentModel;

namespace AccountingForPotentiallyDangObj.Web.Models
{
    public class SubjectViewModel
    {
        public int Id { get; set; }

        [DisplayName("Наименование субъекта")]
        public string Name { get; set; }

        [DisplayName("УНП субъекта")]
        public int UNP { get; set; }
        [DisplayName("ID Ведомственная принадлежность субъекта")]
        public int DepartmentalAffiliationId { get; set; }
        [DisplayName("Ведомственная принадлежность субъекта")]
        public string DepartmentalAffiliationName { get; set; }
        public DepartmentalAffiliation DepartmentalAffiliation { get; set; }
        [DisplayName("Почтовый адрес субъекта")]
        public string postalAddress { get; set; }
        [DisplayName("Телефон субъекта")]
        public string phone { get; set; }
    }
}
