namespace AccountAuditory.Models.Dto
{

    public class AuditoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }

        public int Number { get; set; }
        public int BuildingId { get; set; }
        public string? BuildingName { get; set; }

        public int TypeRoomId { get; set; }
        public string? TypeRoomName { get; set; }

    }
}
