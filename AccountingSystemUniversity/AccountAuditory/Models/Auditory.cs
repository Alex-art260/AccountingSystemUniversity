using System.ComponentModel.DataAnnotations.Schema;

namespace AccountAuditory.Models
{
    [Table("Auditory", Schema = "public")]
    public class Auditory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }

        public int Number { get; set; }

        public int BuildingId { get; set; }
        public Buildings? Buildings { get; set; }

        public int TypeRoomId { get; set; }
        public TypeRoom? TypeRoom { get; set; }

    }
}
