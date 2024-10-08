using System.ComponentModel.DataAnnotations.Schema;

namespace AccountAuditory.Models
{
    [Table("Buildings", Schema = "public")]
    public class Buildings
    {
        public int Id { get; set; }
        public string? Name { get; set; }    
    }
}
