using AccountingSystemUniversity.Models.Dto;

namespace AccountingSystemUniversity.Interfaces
{
    public interface IBuildingService
    {
        Task<int> Create(BuildingDto dto); 
        Task<List<BuildingDto>> GetBuildings();
        Task<int> Delete(int id);
        Task<int> UpdateBuilding(BuildingDto dto);
    }
}
