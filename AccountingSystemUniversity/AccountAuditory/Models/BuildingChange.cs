namespace AccountAuditory.Models
{
    public class BuildingChange
    {
        public int BuildingId { get; set; }
        public string? BuildingName { get; set; }

        public string? Action { get; set; } // "Create", "Update", "Delete" 
    }
}
