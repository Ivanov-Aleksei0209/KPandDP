using System.ComponentModel;

namespace AccountingForPotentiallyDangObj.Web.DtoModels
{
    public class InspectorDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
        public int RoleId { get; set; }
    }
}
