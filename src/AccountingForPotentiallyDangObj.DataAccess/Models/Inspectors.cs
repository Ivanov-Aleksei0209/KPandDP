using System.ComponentModel.DataAnnotations;

namespace AccountingForPotentiallyDangObj.DataAccess.Models
{
    public class Inspectors
        // сделать рефакторинг кода на единственное число
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
