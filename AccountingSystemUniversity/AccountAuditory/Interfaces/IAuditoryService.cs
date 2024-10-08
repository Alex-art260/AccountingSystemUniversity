using AccountAuditory.Models.Dto;

namespace AccountAuditory.Interfaces
{
    public interface IAuditoryService
    {
        Task<int> Create(AuditoryDto dto);
        Task<List<AuditoryDto>> GetAuditoriums();
        Task<int> Delete(int id);
        Task<int> UpdateAuditoriums(AuditoryDto dto);
        Task<List<BuildingDto>> GetBuildings();
        Task<List<TypeRoomDto>> GetTypeRooms();
        Task<int> Create(BuildingDto dto);
        Task<int> UpdateBuilding(BuildingDto dto);
         Task<int> DeleteBuilding(int id);
    }
}
