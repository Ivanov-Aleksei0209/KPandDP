using System.ComponentModel;

namespace AccountingForPotentiallyDangObj.Web.Models
{
    public class InspectorViewModel
    {
        [DisplayName("№ п/п")]
        public int Id { get; set; }

        [DisplayName("Фамилия И.О.")]
        public string Name { get; set; }

        //[DisplayName("Должность")]
        //public string Role { get; set; }

        [DisplayName("Должность")]
        public string RoleName { get; set; }
    }
}
