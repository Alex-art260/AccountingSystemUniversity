using System.ComponentModel.DataAnnotations.Schema;

namespace AccountAuditory.Models
{
    [Table("TypeRoom", Schema = "public")]
    public class TypeRoom
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
