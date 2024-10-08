using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingSystemUniversity.Models
{
    [Table("Building", Schema = "public")]
    public class Building
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Floor { get; set; }

        public string? Other { get; set; }
    }
}
